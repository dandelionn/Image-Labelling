namespace ImageLabellingTool
{
    partial class BoundingBoxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoundingBoxForm));
            this.buttonOpenImagesDir = new System.Windows.Forms.Button();
            this.textBoxImagesDir = new System.Windows.Forms.TextBox();
            this.buttonSetImagesDir = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.listBoxImages = new System.Windows.Forms.ListBox();
            this.buttonViewImage = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonRemoveBoundingBox = new System.Windows.Forms.Button();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.textBoxImagePath = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxSaveDirPath = new System.Windows.Forms.TextBox();
            this.buttonOpenSaveDir = new System.Windows.Forms.Button();
            this.buttonSetSaveDir = new System.Windows.Forms.Button();
            this.buttonSaveImageData = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpenImagesDir
            // 
            this.buttonOpenImagesDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenImagesDir.BackColor = System.Drawing.Color.White;
            this.buttonOpenImagesDir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOpenImagesDir.BackgroundImage")));
            this.buttonOpenImagesDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOpenImagesDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenImagesDir.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonOpenImagesDir.ForeColor = System.Drawing.Color.Black;
            this.buttonOpenImagesDir.Location = new System.Drawing.Point(809, 522);
            this.buttonOpenImagesDir.Name = "buttonOpenImagesDir";
            this.buttonOpenImagesDir.Size = new System.Drawing.Size(35, 31);
            this.buttonOpenImagesDir.TabIndex = 55;
            this.buttonOpenImagesDir.UseVisualStyleBackColor = false;
            this.buttonOpenImagesDir.Click += new System.EventHandler(this.buttonOpenImagesDir_Click);
            // 
            // textBoxImagesDir
            // 
            this.textBoxImagesDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxImagesDir.BackColor = System.Drawing.Color.DimGray;
            this.textBoxImagesDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxImagesDir.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.textBoxImagesDir.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.textBoxImagesDir.Location = new System.Drawing.Point(46, 528);
            this.textBoxImagesDir.Name = "textBoxImagesDir";
            this.textBoxImagesDir.ReadOnly = true;
            this.textBoxImagesDir.Size = new System.Drawing.Size(757, 19);
            this.textBoxImagesDir.TabIndex = 54;
            // 
            // buttonSetImagesDir
            // 
            this.buttonSetImagesDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSetImagesDir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSetImagesDir.BackgroundImage")));
            this.buttonSetImagesDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSetImagesDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetImagesDir.Location = new System.Drawing.Point(5, 522);
            this.buttonSetImagesDir.Name = "buttonSetImagesDir";
            this.buttonSetImagesDir.Size = new System.Drawing.Size(35, 31);
            this.buttonSetImagesDir.TabIndex = 53;
            this.buttonSetImagesDir.UseVisualStyleBackColor = true;
            this.buttonSetImagesDir.Click += new System.EventHandler(this.buttonSetImagesDir_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrev.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPrev.BackgroundImage")));
            this.buttonPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrev.Location = new System.Drawing.Point(680, 4);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(51, 31);
            this.buttonPrev.TabIndex = 52;
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNext.BackgroundImage")));
            this.buttonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Location = new System.Drawing.Point(793, 4);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(51, 31);
            this.buttonNext.TabIndex = 51;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // listBoxImages
            // 
            this.listBoxImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxImages.BackColor = System.Drawing.Color.DimGray;
            this.listBoxImages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxImages.Font = new System.Drawing.Font("Sitka Text", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxImages.FormattingEnabled = true;
            this.listBoxImages.ItemHeight = 19;
            this.listBoxImages.Location = new System.Drawing.Point(680, 38);
            this.listBoxImages.Name = "listBoxImages";
            this.listBoxImages.Size = new System.Drawing.Size(164, 475);
            this.listBoxImages.TabIndex = 50;
            this.listBoxImages.SelectedIndexChanged += new System.EventHandler(this.listBoxImages_SelectedIndexChanged);
            // 
            // buttonViewImage
            // 
            this.buttonViewImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonViewImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonViewImage.BackgroundImage")));
            this.buttonViewImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonViewImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonViewImage.Location = new System.Drawing.Point(809, 557);
            this.buttonViewImage.Name = "buttonViewImage";
            this.buttonViewImage.Size = new System.Drawing.Size(35, 31);
            this.buttonViewImage.TabIndex = 49;
            this.buttonViewImage.UseVisualStyleBackColor = true;
            this.buttonViewImage.Click += new System.EventHandler(this.buttonViewImage_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.White;
            this.buttonClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClear.BackgroundImage")));
            this.buttonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonClear.ForeColor = System.Drawing.Color.Black;
            this.buttonClear.Location = new System.Drawing.Point(46, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(35, 31);
            this.buttonClear.TabIndex = 48;
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonRemoveBoundingBox
            // 
            this.buttonRemoveBoundingBox.BackColor = System.Drawing.Color.White;
            this.buttonRemoveBoundingBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRemoveBoundingBox.BackgroundImage")));
            this.buttonRemoveBoundingBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRemoveBoundingBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveBoundingBox.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonRemoveBoundingBox.ForeColor = System.Drawing.Color.Black;
            this.buttonRemoveBoundingBox.Location = new System.Drawing.Point(5, 4);
            this.buttonRemoveBoundingBox.Name = "buttonRemoveBoundingBox";
            this.buttonRemoveBoundingBox.Size = new System.Drawing.Size(35, 31);
            this.buttonRemoveBoundingBox.TabIndex = 47;
            this.buttonRemoveBoundingBox.UseVisualStyleBackColor = false;
            this.buttonRemoveBoundingBox.Click += new System.EventHandler(this.buttonRemoveBoundingBox_Click);
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoadImage.BackColor = System.Drawing.Color.White;
            this.buttonLoadImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLoadImage.BackgroundImage")));
            this.buttonLoadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadImage.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonLoadImage.ForeColor = System.Drawing.Color.Black;
            this.buttonLoadImage.Location = new System.Drawing.Point(5, 557);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(35, 31);
            this.buttonLoadImage.TabIndex = 41;
            this.buttonLoadImage.UseVisualStyleBackColor = false;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // textBoxImagePath
            // 
            this.textBoxImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxImagePath.BackColor = System.Drawing.Color.DimGray;
            this.textBoxImagePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxImagePath.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.textBoxImagePath.Location = new System.Drawing.Point(46, 564);
            this.textBoxImagePath.Name = "textBoxImagePath";
            this.textBoxImagePath.ReadOnly = true;
            this.textBoxImagePath.Size = new System.Drawing.Size(757, 19);
            this.textBoxImagePath.TabIndex = 40;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.DimGray;
            this.flowLayoutPanel.Controls.Add(this.pictureBox);
            this.flowLayoutPanel.Font = new System.Drawing.Font("Sitka Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel.Location = new System.Drawing.Point(5, 38);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(669, 475);
            this.flowLayoutPanel.TabIndex = 38;
            // 
            // textBoxSaveDirPath
            // 
            this.textBoxSaveDirPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSaveDirPath.BackColor = System.Drawing.Color.DimGray;
            this.textBoxSaveDirPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSaveDirPath.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.textBoxSaveDirPath.ForeColor = System.Drawing.Color.LimeGreen;
            this.textBoxSaveDirPath.Location = new System.Drawing.Point(46, 599);
            this.textBoxSaveDirPath.Name = "textBoxSaveDirPath";
            this.textBoxSaveDirPath.ReadOnly = true;
            this.textBoxSaveDirPath.Size = new System.Drawing.Size(757, 19);
            this.textBoxSaveDirPath.TabIndex = 37;
            // 
            // buttonOpenSaveDir
            // 
            this.buttonOpenSaveDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenSaveDir.BackColor = System.Drawing.Color.White;
            this.buttonOpenSaveDir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOpenSaveDir.BackgroundImage")));
            this.buttonOpenSaveDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOpenSaveDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenSaveDir.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonOpenSaveDir.ForeColor = System.Drawing.Color.Black;
            this.buttonOpenSaveDir.Location = new System.Drawing.Point(809, 592);
            this.buttonOpenSaveDir.Name = "buttonOpenSaveDir";
            this.buttonOpenSaveDir.Size = new System.Drawing.Size(35, 31);
            this.buttonOpenSaveDir.TabIndex = 36;
            this.buttonOpenSaveDir.UseVisualStyleBackColor = false;
            this.buttonOpenSaveDir.Click += new System.EventHandler(this.buttonOpenSaveDir_Click);
            // 
            // buttonSetSaveDir
            // 
            this.buttonSetSaveDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSetSaveDir.BackColor = System.Drawing.Color.White;
            this.buttonSetSaveDir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSetSaveDir.BackgroundImage")));
            this.buttonSetSaveDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSetSaveDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetSaveDir.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonSetSaveDir.ForeColor = System.Drawing.Color.Black;
            this.buttonSetSaveDir.Location = new System.Drawing.Point(5, 592);
            this.buttonSetSaveDir.Name = "buttonSetSaveDir";
            this.buttonSetSaveDir.Size = new System.Drawing.Size(35, 31);
            this.buttonSetSaveDir.TabIndex = 35;
            this.buttonSetSaveDir.UseVisualStyleBackColor = false;
            this.buttonSetSaveDir.Click += new System.EventHandler(this.buttonSetSaveDir_Click);
            // 
            // buttonSaveImageData
            // 
            this.buttonSaveImageData.BackColor = System.Drawing.Color.Black;
            this.buttonSaveImageData.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSaveImageData.BackgroundImage")));
            this.buttonSaveImageData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSaveImageData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveImageData.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonSaveImageData.ForeColor = System.Drawing.Color.Black;
            this.buttonSaveImageData.Location = new System.Drawing.Point(376, 4);
            this.buttonSaveImageData.Name = "buttonSaveImageData";
            this.buttonSaveImageData.Size = new System.Drawing.Size(35, 31);
            this.buttonSaveImageData.TabIndex = 34;
            this.buttonSaveImageData.UseVisualStyleBackColor = false;
            this.buttonSaveImageData.Click += new System.EventHandler(this.buttonSaveImageData_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(435, 365);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // BoundingBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(849, 627);
            this.Controls.Add(this.buttonOpenImagesDir);
            this.Controls.Add(this.textBoxImagesDir);
            this.Controls.Add(this.buttonSetImagesDir);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.listBoxImages);
            this.Controls.Add(this.buttonViewImage);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonRemoveBoundingBox);
            this.Controls.Add(this.buttonLoadImage);
            this.Controls.Add(this.textBoxImagePath);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.textBoxSaveDirPath);
            this.Controls.Add(this.buttonOpenSaveDir);
            this.Controls.Add(this.buttonSetSaveDir);
            this.Controls.Add(this.buttonSaveImageData);
            this.Name = "BoundingBoxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bounding box";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BoundingBoxForm_FormClosed);
            this.flowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenImagesDir;
        private System.Windows.Forms.TextBox textBoxImagesDir;
        private System.Windows.Forms.Button buttonSetImagesDir;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.ListBox listBoxImages;
        private System.Windows.Forms.Button buttonViewImage;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonRemoveBoundingBox;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.TextBox textBoxImagePath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.TextBox textBoxSaveDirPath;
        private System.Windows.Forms.Button buttonOpenSaveDir;
        private System.Windows.Forms.Button buttonSetSaveDir;
        private System.Windows.Forms.Button buttonSaveImageData;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}