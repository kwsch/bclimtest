namespace bclimtest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.B_Go = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.L_TileHeight = new System.Windows.Forms.Label();
            this.L_TileWidth = new System.Windows.Forms.Label();
            this.L_Height = new System.Windows.Forms.Label();
            this.L_Width = new System.Windows.Forms.Label();
            this.L_Extension = new System.Windows.Forms.Label();
            this.L_FileName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.L_FileFormat = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.L_Colors = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.L_Format = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.PaletteBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(218, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 128);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMH);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(335, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.ChangeText);
            // 
            // B_Go
            // 
            this.B_Go.Enabled = false;
            this.B_Go.Location = new System.Drawing.Point(93, 12);
            this.B_Go.Name = "B_Go";
            this.B_Go.Size = new System.Drawing.Size(75, 23);
            this.B_Go.TabIndex = 3;
            this.B_Go.Text = "Go";
            this.B_Go.UseVisualStyleBackColor = true;
            this.B_Go.Click += new System.EventHandler(this.B_Go_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "FileName:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Extension:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Image Width:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Image Height:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tile Width:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Tile Height:";
            // 
            // L_TileHeight
            // 
            this.L_TileHeight.AutoSize = true;
            this.L_TileHeight.Location = new System.Drawing.Point(81, 149);
            this.L_TileHeight.Name = "L_TileHeight";
            this.L_TileHeight.Size = new System.Drawing.Size(22, 13);
            this.L_TileHeight.TabIndex = 20;
            this.L_TileHeight.Text = "(th)";
            // 
            // L_TileWidth
            // 
            this.L_TileWidth.AutoSize = true;
            this.L_TileWidth.Location = new System.Drawing.Point(81, 136);
            this.L_TileWidth.Name = "L_TileWidth";
            this.L_TileWidth.Size = new System.Drawing.Size(24, 13);
            this.L_TileWidth.TabIndex = 19;
            this.L_TileWidth.Text = "(tw)";
            // 
            // L_Height
            // 
            this.L_Height.AutoSize = true;
            this.L_Height.Location = new System.Drawing.Point(81, 122);
            this.L_Height.Name = "L_Height";
            this.L_Height.Size = new System.Drawing.Size(19, 13);
            this.L_Height.TabIndex = 18;
            this.L_Height.Text = "(h)";
            // 
            // L_Width
            // 
            this.L_Width.AutoSize = true;
            this.L_Width.Location = new System.Drawing.Point(81, 109);
            this.L_Width.Name = "L_Width";
            this.L_Width.Size = new System.Drawing.Size(21, 13);
            this.L_Width.TabIndex = 17;
            this.L_Width.Text = "(w)";
            // 
            // L_Extension
            // 
            this.L_Extension.AutoSize = true;
            this.L_Extension.Location = new System.Drawing.Point(81, 34);
            this.L_Extension.Name = "L_Extension";
            this.L_Extension.Size = new System.Drawing.Size(27, 13);
            this.L_Extension.TabIndex = 16;
            this.L_Extension.Text = "(ext)";
            // 
            // L_FileName
            // 
            this.L_FileName.AutoSize = true;
            this.L_FileName.Location = new System.Drawing.Point(81, 20);
            this.L_FileName.Name = "L_FileName";
            this.L_FileName.Size = new System.Drawing.Size(39, 13);
            this.L_FileName.TabIndex = 14;
            this.L_FileName.Text = "(name)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.L_FileFormat);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.L_Colors);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.L_Format);
            this.groupBox1.Controls.Add(this.L_TileHeight);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.L_TileWidth);
            this.groupBox1.Controls.Add(this.L_Height);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.L_Width);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.L_Extension);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.L_FileName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 165);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details:";
            this.groupBox1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "FileFormat:";
            // 
            // L_FileFormat
            // 
            this.L_FileFormat.AutoSize = true;
            this.L_FileFormat.Location = new System.Drawing.Point(81, 47);
            this.L_FileFormat.Name = "L_FileFormat";
            this.L_FileFormat.Size = new System.Drawing.Size(27, 13);
            this.L_FileFormat.TabIndex = 26;
            this.L_FileFormat.Text = "(fmt)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Colors:";
            // 
            // L_Colors
            // 
            this.L_Colors.AutoSize = true;
            this.L_Colors.Location = new System.Drawing.Point(81, 80);
            this.L_Colors.Name = "L_Colors";
            this.L_Colors.Size = new System.Drawing.Size(25, 13);
            this.L_Colors.TabIndex = 24;
            this.L_Colors.Text = "(cc)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Color Format:";
            // 
            // L_Format
            // 
            this.L_Format.AutoSize = true;
            this.L_Format.Location = new System.Drawing.Point(81, 67);
            this.L_Format.Name = "L_Format";
            this.L_Format.Size = new System.Drawing.Size(22, 13);
            this.L_Format.TabIndex = 22;
            this.L_Format.Text = "(cf)";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(174, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "Save .PNG";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(260, 16);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(76, 17);
            this.checkBox2.TabIndex = 23;
            this.checkBox2.Text = "Don\'t Crop";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // PaletteBox
            // 
            this.PaletteBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PaletteBox.Location = new System.Drawing.Point(218, 62);
            this.PaletteBox.Name = "PaletteBox";
            this.PaletteBox.Size = new System.Drawing.Size(80, 10);
            this.PaletteBox.TabIndex = 27;
            this.PaletteBox.TabStop = false;
            this.PaletteBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 242);
            this.Controls.Add(this.PaletteBox);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.B_Go);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.MinimumSize = new System.Drawing.Size(375, 280);
            this.Name = "Form1";
            this.Text = "BCLIM Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button B_Go;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label L_TileHeight;
        private System.Windows.Forms.Label L_TileWidth;
        private System.Windows.Forms.Label L_Height;
        private System.Windows.Forms.Label L_Width;
        private System.Windows.Forms.Label L_Extension;
        private System.Windows.Forms.Label L_FileName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label L_Colors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label L_Format;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label L_FileFormat;
        private System.Windows.Forms.PictureBox PaletteBox;
    }
}

