using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace bclimtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            #region Enable Drag and Drop on the form & tab control.
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(tabMain_DragEnter);
            this.DragDrop += new DragEventHandler(tabMain_DragDrop);

            // Enable Drag and Drop on each tab.
            this.DragEnter += new DragEventHandler(tabMain_DragEnter);
            this.DragDrop += new DragEventHandler(tabMain_DragDrop);
            #endregion
        }
        private void tabMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        private void tabMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string path = files[0]; // open first D&D
            textBox1.Text = path;
            if (files.Length >= 1)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    textBox1.Text = files[i];
                    B_Go_Click(null, null);
                }
            }
        }

        #region Morton Translation
        UInt32 DM2X(UInt32 code)
        {
            return C11(code >> 0);
        }
        UInt32 DM2Y(UInt32 code)
        {
            return C11(code >> 1);
        }
        UInt32 C11(UInt32 x)
        {
            x &= 0x55555555;                  // x = -f-e -d-c -b-a -9-8 -7-6 -5-4 -3-2 -1-0
            x = (x ^ (x >> 1)) & 0x33333333; // x = --fe --dc --ba --98 --76 --54 --32 --10
            x = (x ^ (x >> 2)) & 0x0f0f0f0f; // x = ---- fedc ---- ba98 ---- 7654 ---- 3210
            x = (x ^ (x >> 4)) & 0x00ff00ff; // x = ---- ---- fedc ba98 ---- ---- 7654 3210
            x = (x ^ (x >> 8)) & 0x0000ffff; // x = ---- ---- ---- ---- fedc ba98 7654 3210
            return x;
        }
        #endregion
        #region Colors and CLIM Structure
        private static readonly int[] Convert5To8 = { 0x00,0x08,0x10,0x18,0x20,0x29,0x31,0x39,
                                                0x41,0x4A,0x52,0x5A,0x62,0x6A,0x73,0x7B,
                                                0x83,0x8B,0x94,0x9C,0xA4,0xAC,0xB4,0xBD,
                                                0xC5,0xCD,0xD5,0xDE,0xE6,0xEE,0xF6,0xFF };
        private static Color DecodeColor(int val, int pixelFormat)
        {
            int alpha = 0xFF, red, green, blue;
            switch (pixelFormat)
            {
                case 0: // PixelFormat.RGBA8:
                    red = (val >> 24) & 0xFF;
                    green = (val >> 16) & 0xFF;
                    blue = (val >> 8) & 0xFF;
                    alpha = val & 0xFF;
                    return Color.FromArgb(alpha, red, green, blue);
                case 1: // PixelFormat.RGB8:
                    red = (val >> 16) & 0xFF;
                    green = (val >> 8) & 0xFF;
                    blue = val & 0xFF;
                    return Color.FromArgb(alpha, red, green, blue);
                case 2: // PixelFormat.RGBA5551:
                    red = Convert5To8[(val >> 11) & 0x1F];
                    green = Convert5To8[(val >> 6) & 0x1F];
                    blue = Convert5To8[(val >> 1) & 0x1F];
                    alpha = (val & 0x0001) == 1 ? 0xFF : 0x00;
                    return Color.FromArgb(alpha, red, green, blue);
                case 3: // PixelFormat.RGB565:
                    red = Convert5To8[(val >> 11) & 0x1F];
                    green = ((val >> 5) & 0x3F) * 4;
                    blue = Convert5To8[val & 0x1F];
                    return Color.FromArgb(alpha, red, green, blue);
                case 4: // PixelFormat.RGBA4:
                    alpha = 0x11 * (val & 0xf);
                    red = 0x11 * ((val >> 12) & 0xf);
                    green = 0x11 * ((val >> 8) & 0xf);
                    blue = 0x11 * ((val >> 4) & 0xf);
                    return Color.FromArgb(alpha, red, green, blue);
                case 5: // PixelFormat.LA8:
                    red = (val >> 8) 0xFF;
                    alpha = val & 0xFF;
                    return Color.FromArgb(alpha, red, red, red);
                case 6: // PixelFormat.HILO8: //use only the HI
                    red = val >> 8;
                    return Color.FromArgb(alpha, red, red, red);
                case 7: // PixelFormat.L8:
                    return Color.FromArgb(alpha, val, val, val);
                case 8: // PixelFormat.A8:
                    return Color.FromArgb(val, alpha, alpha, alpha);
                case 9: // PixelFormat.LA4:
                    red = val >> 4;
                    alpha = val & 0x0F;
                    return Color.FromArgb(alpha, red, red, red);
                default:
                    return Color.White;
            }
        }
        private static int nlpo2(int x)
        {
            x--; // comment out to always take the next biggest power of two, even if x is already a power of two
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            return (x+1);
        }
        private static int gcm(int m, int n)
        {
            return ((m + n - 1) / n) * n;
        }
        public class BCLIM
        {
            public static CLIM analyze(string path)
            {
                CLIM bclim = new CLIM();
                bclim.FileName = Path.GetFileNameWithoutExtension(path);
                bclim.FilePath = Path.GetDirectoryName(path);
                bclim.Extension = Path.GetExtension(path);
                BinaryReader br = new BinaryReader(System.IO.File.OpenRead(path));
                long len = br.BaseStream.Length;
                int offset = 0;

                bclim.Magic = br.ReadUInt32();   

                if (bclim.Magic == 0x4D494C43)
                {
                    // Header is header.
                    br.BaseStream.Seek(0, SeekOrigin.Begin);
                    offset = 0x28;
                }
                else
                {
                    // Header is footer.
                    br.BaseStream.Seek(len - 0x28, SeekOrigin.Begin);
                    bclim.Magic = br.ReadUInt32();
                }

                bclim.BOM           = br.ReadUInt16();
                bclim.CLIMLength    = br.ReadUInt32();
                bclim.TileWidth     = 2 << br.ReadByte();
                bclim.TileHeight    = 2 << br.ReadByte();
                bclim.totalLength   = br.ReadUInt32();
                bclim.Count = br.ReadUInt32();

                bclim.imag = br.ReadChars(4);
                bclim.imagLength = br.ReadUInt32();
                bclim.Width = br.ReadUInt16();
                bclim.Height = br.ReadUInt16();
                bclim.FileFormat = br.ReadInt32();
                bclim.dataLength = br.ReadUInt32();

                bclim.BaseSize = Math.Max(nlpo2(bclim.Width), nlpo2(bclim.Height));

                br.BaseStream.Seek(offset, SeekOrigin.Begin);
                bclim.Data = br.ReadBytes((int)bclim.dataLength);

                bclim.ColorFormat = getFormat(bclim.FileFormat);

                return bclim;
            }
        }
        public struct CLIM
        {
            public UInt32 Magic;         // CLIM = 0x4D494C43
            public UInt16 BOM;          // 0xFFFE
            public UInt32 CLIMLength;   // HeaderLength - 14
            public int TileWidth;      // 1<<[[n]]
            public int TileHeight;     // 1<<[[n]]
            public UInt32 totalLength;  // Total Length of file
            public UInt32 Count;        // "1" , guessing it's just Count.

            public char[] imag;         // imag = 0x67616D69
            public UInt32 imagLength;   // HeaderLength - 10
            public UInt16 Width;        // Final Dimensions
            public UInt16 Height;       // Final Dimensions
            public Int32 FileFormat;           // ??
            public UInt32 dataLength;   // Pixel Data Region Length

            public byte[] Data;

            public Int32 BaseSize;

            // Contained Data
            public int ColorFormat;
            public int ColorCount;
            public Color[] Colors;

            public int[] Pixels;

            public string FileName;
            public string FilePath;
            public string Extension;

        }
        #endregion

        public PixelFormat GetPixelFormat(int val)
        {
            switch (val)
            {
                case 0: return PixelFormat.Format32bppArgb;
                case 1: //return PixelFormat.Format32bppRgb; // RGB8
                case 2: return PixelFormat.Format16bppRgb555;
                case 3: return PixelFormat.Format16bppRgb565;
                case 4: //return PixelFormat.DontCare; // 4444argb not in c#
                case 5: //return PixelFormat.DontCare; // LA8 not in c#
                case 6: //return PixelFormat.DontCare; // Hilo8
                case 7: //return PixelFormat.DontCare; // L8
                case 8: //return PixelFormat.DontCare; // A8
                case 9: //return PixelFormat.DontCare; // LA4
                case 10: //return PixelFormat.DontCare; // L4
                case 11: //return PixelFormat.DontCare; // A4
                case 12: //return PixelFormat.DontCare; // Etc1
                case 13: //return PixelFormat.DontCare; // Etc1A4
                default: return PixelFormat.Format32bppArgb;
            }
        }
        public static int getFormat(int val)
        {
            switch (val)
            {
                case 0: return 7;
                case 1: return 8;
                case 2: return 9;
                case 3: return 5;
                case 4: return 6;
                case 5: return 3;
                case 6: return 1;
                case 7: return 2;
                case 8: return 4;
                case 9: return 0;
                case 10: return 12;
                case 11: return 13;
                case 12: return 10;
                case 13: return 13;
                case 19: return 12;
                default: return 0;
            }
        }

        public void makebmp(string path)
        {
            PaletteBox.Visible = false;
            pictureBox1.Image = null;
            CLIM bclim = BCLIM.analyze(path);
            if (bclim.Magic != 0x4D494C43)
            {
                return;
            }
            // Label up.
            L_Extension.Text = bclim.Extension;
            L_FileName.Text = bclim.FileName;
            L_FileFormat.Text = bclim.FileFormat.ToString();
            L_Colors.Text = bclim.ColorCount.ToString();
            L_Width.Text = bclim.Width.ToString();
            L_Height.Text = bclim.Height.ToString();
            L_TileWidth.Text = bclim.TileWidth.ToString();
            L_TileHeight.Text = bclim.TileHeight.ToString();
            groupBox1.Visible = true;

            L_FileFormat.Text = bclim.FileFormat.ToString();

            if (getFormat(bclim.FileFormat) > 10)
            {
                // ETC1(A4) compressed, not supported
                MessageBox.Show("Ericsson Compressed bclims are not supported.");
                return;
            }


            L_Format.Text = GetPixelFormat(bclim.ColorFormat).ToString();
            // Make image
            int width = 0; 
            int height = 0;
            PixelFormat format = PixelFormat.Format32bppArgb;

            // for format=0, we don't use a square image, and we use a different pixel format.
            if (bclim.FileFormat == 3)
            {
                #region 3
                // Square Format
                width = height = bclim.BaseSize;
                int firstcolor = BitConverter.ToInt16(bclim.Data,0);
                bclim.Colors = new Color[bclim.dataLength / 2];
                bclim.Pixels = new int[bclim.dataLength / 2];

                L_Colors.Text = "N/A";

                for (int i = 0; i < bclim.Colors.Length; i++)
                {
                    // fill up
                    int val = BitConverter.ToInt16(bclim.Data, i * 2);
                    if (val != firstcolor)
                    {
                        bclim.Colors[i] = DecodeColor(val, bclim.ColorFormat); // Read Color
                    }
                    else
                    {
                        bclim.Colors[i] = Color.Transparent;
                    }
                    bclim.Pixels[i] = i;    // Respective Pixel/Color
                }
                #endregion
            }
            else if (bclim.FileFormat == 7 )
            {
                #region 7
                if (bclim.Data[1] != 0)
                {
                    {
                        #region 8
                        
                        width = bclim.BaseSize;
                        height = bclim.BaseSize;
                        bclim.ColorFormat = 2;
                        bclim.Colors = new Color[bclim.dataLength / 2];
                        bclim.Pixels = new int[bclim.dataLength / 2];

                        L_Colors.Text = "N/A";
                        L_Format.Text = GetPixelFormat(bclim.ColorFormat).ToString()+"_1";

                        for (int i = 0; i < bclim.Colors.Length; i++)
                        {
                            // fill up
                            bclim.Colors[i] = DecodeColor(BitConverter.ToInt16(bclim.Data, i * 2), bclim.ColorFormat); // Read Color
                            bclim.Pixels[i] = i;    // Respective Pixel/Color
                        }
                        #endregion
                    }
                }
                else
                {
                    // Square Format
                    width = height = bclim.BaseSize;
                    bclim.ColorFormat = BitConverter.ToUInt16(bclim.Data, 0);
                    //format = getPixelFormat(bclim.ColorFormat);
                    bclim.ColorCount = BitConverter.ToUInt16(bclim.Data, 2);

                    L_Format.Text = GetPixelFormat(bclim.ColorFormat).ToString();
                    L_Colors.Text = bclim.ColorCount.ToString();
                    format = PixelFormat.Format32bppArgb;
                    bclim.Colors = new Color[bclim.ColorCount];
                    for (int i = 0; i < bclim.ColorCount; i++)
                    {
                        bclim.Colors[i] = DecodeColor(BitConverter.ToUInt16(bclim.Data, 4 + 2 * i), bclim.ColorFormat);
                    }
                    bclim.Pixels = new int[bclim.BaseSize * bclim.BaseSize];

                    int offset = 2 * (bclim.ColorCount + 2);
                    if (bclim.ColorCount <= 0x10) // 4 bits per color chosen
                    {
                        for (long i = 0; i < (bclim.Pixels.Length - offset) / 2; i++)
                        {
                            byte dp = bclim.Data[i + offset];
                            bclim.Pixels[2 * i] = dp >> 4;
                            bclim.Pixels[2 * i + 1] = dp & 0xF;
                        }
                    }
                    else // 8 bits per color chosen
                    {
                        for (long i = 2 * (bclim.ColorCount + 2); i < bclim.Pixels.Length - offset; i++)
                        {
                            bclim.Pixels[i] = bclim.Data[i + offset];
                        }
                    }

                    // Palette Box
                    Bitmap palette = new Bitmap(bclim.ColorCount * 8, 8, PixelFormat.Format32bppArgb);
                    for (int i = 0; i < bclim.ColorCount * 8; i++)
                    {
                        for (int j = 0; j < 8; j++) { palette.SetPixel(i, j, bclim.Colors[i / 8]); }
                    }
                    PaletteBox.Image = palette; PaletteBox.Visible = true;
                    PaletteBox.Width = 2 + 8 * bclim.ColorCount;
                    PaletteBox.Height = 2 + 8;
                    PaletteBox.BorderStyle = BorderStyle.FixedSingle;
                }
                #endregion
            }
            else if (bclim.FileFormat == 8)
            {
                #region 8
                //format = PixelFormat.Format32bppArgb;
                width = bclim.BaseSize;
                height = bclim.BaseSize;
                bclim.ColorFormat = 4;
                bclim.Colors = new Color[bclim.dataLength / 2];
                bclim.Pixels = new int[bclim.dataLength / 2];

                L_Colors.Text = "N/A";
                L_Format.Text = "ARGB4444";

                for (int i = 0; i < bclim.Colors.Length; i++)
                {
                    // fill up
                    bclim.Colors[i] = DecodeColor(BitConverter.ToInt16(bclim.Data, i * 2), bclim.ColorFormat); // Read Color
                    bclim.Pixels[i] = i;    // Respective Pixel/Color
                }
                #endregion
            }
            else if (bclim.FileFormat == 9)
            {
                #region 9
                // Raw width has to be a multiple of 8 greater than the width.
                //format = PixelFormat.Format32bppArgb;
                width = bclim.BaseSize;
                height = bclim.BaseSize;

                L_Colors.Text = "N/A";
                L_Format.Text = "RGBA8";

                // 32bpp
                bclim.ColorFormat = 0;

                bclim.Colors = new Color[bclim.dataLength / 4];
                bclim.Pixels = new int[bclim.dataLength / 4];
                for (int i = 0; i < bclim.Colors.Length; i++)
                {
                    // fill up
                    bclim.Colors[i] = DecodeColor(BitConverter.ToInt32(bclim.Data, i * 4), bclim.ColorFormat); // Read Color
                    bclim.Pixels[i] = i;    // Respective Pixel/Color
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Unsupported BCLIM format.");
                return;
            }

            Bitmap myBitmap = new Bitmap(gcm(width, 8), gcm(width, 8), format);
            //bclim.Colors[0] = Color.Transparent;

            // Build Bitmap
            int p = gcm(width, 8) / 8;
            if (p == 0) p = 1;
            for (uint i = 0; i < gcm(width, 8) * gcm(height, 8); i++)
            {
                // Get Tile Coordinate
                int x = (int)DM2X(i % 64); // to 8x8 tile
                int y = (int)DM2Y(i % 64); // to 8x8 tile

                // Get Tilemap Coordinate
                int tile = (int)i / 64;
                int xsh = (tile % p) * 8;
                int ysh = (tile / p) * 8;

                // Shift Tile Coordinate into Tilemap
                x += xsh;
                y += ysh;

                if (i >= bclim.Pixels.Length)
                    break;
                int pv = bclim.Pixels[i];
                Color color = bclim.Colors[pv];
                myBitmap.SetPixel(x, y, color);
            }


            Rectangle cropRect = new Rectangle(0, 0, bclim.Width, bclim.Height);
            Bitmap CropBMP = new Bitmap(cropRect.Width, cropRect.Height);

            using (Graphics g = Graphics.FromImage(CropBMP))
            {
                g.DrawImage(myBitmap, new Rectangle(0, 0, CropBMP.Width, CropBMP.Height),
                                 cropRect,
                                 GraphicsUnit.Pixel);
            }
            if (checkBox2.Checked)
            {
                pictureBox1.Image = myBitmap;
                pbheight = myBitmap.Height;
                pbwidth = myBitmap.Width;
            }
            else
            {
                pictureBox1.Image = CropBMP;
                pbheight = CropBMP.Height;
                pbwidth = CropBMP.Width;
            }
            if (checkBox1.Checked)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    //error will throw from here
                    CropBMP.Save(ms, ImageFormat.Png);
                    byte[] data = ms.ToArray();
                    File.WriteAllBytes(bclim.FilePath + "\\" + bclim.FileName + ".png", data);
                }
            }


            return;
        }
        private void B_Go_Click(object sender, EventArgs e)
        {
            makebmp(textBox1.Text);
        }
        private void B_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }

        private void ChangeText(object sender, EventArgs e)
        {
            textBox1.Select(textBox1.Text.Length, 0);
            if (textBox1.TextLength > 6)
                B_Go.Enabled = true;
        }

        public int pbwidth, pbheight = 0;
        private void pbMH(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                pictureBox1.Width = 2 * pbwidth; pictureBox1.Height = 2 * pbheight;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox1.Width = 1 * pbwidth; pictureBox1.Height = 1 * pbheight;
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            }
        }
    }

}
