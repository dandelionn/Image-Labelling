namespace ImageLabellingTool
{
    partial class ContourForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContourForm));
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.buttonSetSaveDir = new System.Windows.Forms.Button();
            this.buttonOpenSaveDir = new System.Windows.Forms.Button();
            this.textBoxSaveDirPath = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonPolygon = new System.Windows.Forms.Button();
            this.textBoxImagePath = new System.Windows.Forms.TextBox();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.buttonTriangle = new System.Windows.Forms.Button();
            this.buttonTetragon = new System.Windows.Forms.Button();
            this.buttonEllipse = new System.Windows.Forms.Button();
            this.buttonNothing = new System.Windows.Forms.Button();
            this.buttonGenerateContours = new System.Windows.Forms.Button();
            this.buttonRemoveContour = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonViewImage = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonSetImagesDir = new System.Windows.Forms.Button();
            this.textBoxImagesDir = new System.Windows.Forms.TextBox();
            this.buttonOpenImagesDir = new System.Windows.Forms.Button();
            this.listViewImages = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.BackColor = System.Drawing.Color.Black;
            this.buttonSaveImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSaveImage.BackgroundImage")));
            this.buttonSaveImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveImage.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonSaveImage.ForeColor = System.Drawing.Color.Black;
            this.buttonSaveImage.Location = new System.Drawing.Point(567, 4);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(35, 31);
            this.buttonSaveImage.TabIndex = 1;
            this.buttonSaveImage.UseVisualStyleBackColor = false;
            this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
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
            this.buttonSetSaveDir.TabIndex = 4;
            this.buttonSetSaveDir.UseVisualStyleBackColor = false;
            this.buttonSetSaveDir.Click += new System.EventHandler(this.buttonSetSaveDir_Click);
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
            this.buttonOpenSaveDir.TabIndex = 5;
            this.buttonOpenSaveDir.UseVisualStyleBackColor = false;
            this.buttonOpenSaveDir.Click += new System.EventHandler(this.buttonOpenSaveDir_Click);
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
            this.textBoxSaveDirPath.TabIndex = 6;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.DimGray;
            this.flowLayoutPanel.Font = new System.Drawing.Font("Sitka Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel.Location = new System.Drawing.Point(5, 38);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(643, 475);
            this.flowLayoutPanel.TabIndex = 9;
            // 
            // buttonPolygon
            // 
            this.buttonPolygon.BackColor = System.Drawing.Color.White;
            this.buttonPolygon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPolygon.BackgroundImage")));
            this.buttonPolygon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPolygon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPolygon.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonPolygon.ForeColor = System.Drawing.Color.Black;
            this.buttonPolygon.Location = new System.Drawing.Point(128, 4);
            this.buttonPolygon.Name = "buttonPolygon";
            this.buttonPolygon.Size = new System.Drawing.Size(35, 31);
            this.buttonPolygon.TabIndex = 14;
            this.buttonPolygon.UseVisualStyleBackColor = false;
            this.buttonPolygon.Click += new System.EventHandler(this.buttonPolygon_Click);
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
            this.textBoxImagePath.TabIndex = 15;
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
            this.buttonLoadImage.TabIndex = 17;
            this.buttonLoadImage.UseVisualStyleBackColor = false;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // buttonTriangle
            // 
            this.buttonTriangle.BackColor = System.Drawing.Color.White;
            this.buttonTriangle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTriangle.BackgroundImage")));
            this.buttonTriangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTriangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTriangle.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonTriangle.ForeColor = System.Drawing.Color.Black;
            this.buttonTriangle.Location = new System.Drawing.Point(46, 4);
            this.buttonTriangle.Name = "buttonTriangle";
            this.buttonTriangle.Size = new System.Drawing.Size(35, 31);
            this.buttonTriangle.TabIndex = 18;
            this.buttonTriangle.UseVisualStyleBackColor = false;
            this.buttonTriangle.Click += new System.EventHandler(this.buttonTriangle_Click);
            // 
            // buttonTetragon
            // 
            this.buttonTetragon.BackColor = System.Drawing.Color.White;
            this.buttonTetragon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTetragon.BackgroundImage")));
            this.buttonTetragon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTetragon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTetragon.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonTetragon.ForeColor = System.Drawing.Color.Black;
            this.buttonTetragon.Location = new System.Drawing.Point(87, 4);
            this.buttonTetragon.Name = "buttonTetragon";
            this.buttonTetragon.Size = new System.Drawing.Size(35, 31);
            this.buttonTetragon.TabIndex = 19;
            this.buttonTetragon.UseVisualStyleBackColor = false;
            this.buttonTetragon.Click += new System.EventHandler(this.buttonTetragon_Click);
            // 
            // buttonEllipse
            // 
            this.buttonEllipse.BackColor = System.Drawing.Color.White;
            this.buttonEllipse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEllipse.BackgroundImage")));
            this.buttonEllipse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEllipse.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonEllipse.ForeColor = System.Drawing.Color.Black;
            this.buttonEllipse.Location = new System.Drawing.Point(169, 4);
            this.buttonEllipse.Name = "buttonEllipse";
            this.buttonEllipse.Size = new System.Drawing.Size(35, 31);
            this.buttonEllipse.TabIndex = 21;
            this.buttonEllipse.UseVisualStyleBackColor = false;
            this.buttonEllipse.Click += new System.EventHandler(this.buttonEllipse_Click);
            // 
            // buttonNothing
            // 
            this.buttonNothing.BackColor = System.Drawing.Color.Transparent;
            this.buttonNothing.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNothing.BackgroundImage")));
            this.buttonNothing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNothing.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonNothing.ForeColor = System.Drawing.Color.Black;
            this.buttonNothing.Location = new System.Drawing.Point(5, 4);
            this.buttonNothing.Name = "buttonNothing";
            this.buttonNothing.Size = new System.Drawing.Size(35, 31);
            this.buttonNothing.TabIndex = 22;
            this.buttonNothing.UseVisualStyleBackColor = false;
            this.buttonNothing.Click += new System.EventHandler(this.buttonNothing_Click);
            // 
            // buttonGenerateContours
            // 
            this.buttonGenerateContours.BackColor = System.Drawing.Color.White;
            this.buttonGenerateContours.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonGenerateContours.BackgroundImage")));
            this.buttonGenerateContours.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonGenerateContours.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerateContours.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonGenerateContours.ForeColor = System.Drawing.Color.Black;
            this.buttonGenerateContours.Location = new System.Drawing.Point(442, 4);
            this.buttonGenerateContours.Name = "buttonGenerateContours";
            this.buttonGenerateContours.Size = new System.Drawing.Size(35, 31);
            this.buttonGenerateContours.TabIndex = 24;
            this.buttonGenerateContours.UseVisualStyleBackColor = false;
            this.buttonGenerateContours.Click += new System.EventHandler(this.buttonGenerateContours_Click);
            // 
            // buttonRemoveContour
            // 
            this.buttonRemoveContour.BackColor = System.Drawing.Color.White;
            this.buttonRemoveContour.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRemoveContour.BackgroundImage")));
            this.buttonRemoveContour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRemoveContour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveContour.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonRemoveContour.ForeColor = System.Drawing.Color.Black;
            this.buttonRemoveContour.Location = new System.Drawing.Point(287, 4);
            this.buttonRemoveContour.Name = "buttonRemoveContour";
            this.buttonRemoveContour.Size = new System.Drawing.Size(35, 31);
            this.buttonRemoveContour.TabIndex = 25;
            this.buttonRemoveContour.UseVisualStyleBackColor = false;
            this.buttonRemoveContour.Click += new System.EventHandler(this.buttonRemoveContour_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.White;
            this.buttonClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClear.BackgroundImage")));
            this.buttonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Sitka Text", 11.25F);
            this.buttonClear.ForeColor = System.Drawing.Color.Black;
            this.buttonClear.Location = new System.Drawing.Point(328, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(35, 31);
            this.buttonClear.TabIndex = 26;
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
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
            this.buttonViewImage.TabIndex = 27;
            this.buttonViewImage.UseVisualStyleBackColor = true;
            this.buttonViewImage.Click += new System.EventHandler(this.buttonViewImage_Click);
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
            this.buttonNext.TabIndex = 29;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrev.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPrev.BackgroundImage")));
            this.buttonPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrev.Location = new System.Drawing.Point(654, 4);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(51, 31);
            this.buttonPrev.TabIndex = 30;
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
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
            this.buttonSetImagesDir.TabIndex = 31;
            this.buttonSetImagesDir.UseVisualStyleBackColor = true;
            this.buttonSetImagesDir.Click += new System.EventHandler(this.buttonSetImagesDir_Click);
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
            this.textBoxImagesDir.TabIndex = 32;
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
            this.buttonOpenImagesDir.TabIndex = 33;
            this.buttonOpenImagesDir.UseVisualStyleBackColor = false;
            this.buttonOpenImagesDir.Click += new System.EventHandler(this.buttonOpenImagesDir_Click);
            // 
            // listViewImages
            // 
            this.listViewImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewImages.BackColor = System.Drawing.Color.DimGray;
            this.listViewImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.listViewImages.Location = new System.Drawing.Point(654, 38);
            this.listViewImages.MultiSelect = false;
            this.listViewImages.Name = "listViewImages";
            this.listViewImages.OwnerDraw = true;
            this.listViewImages.Size = new System.Drawing.Size(190, 475);
            this.listViewImages.TabIndex = 34;
            this.listViewImages.UseCompatibleStateImageBehavior = false;
            this.listViewImages.View = System.Windows.Forms.View.SmallIcon;
            this.listViewImages.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listViewImages_DrawItem);
            this.listViewImages.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewImages_ItemSelectionChanged);
            this.listViewImages.SizeChanged += new System.EventHandler(this.listViewImages_SizeChanged);
            // 
            // ContourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(849, 627);
            this.Controls.Add(this.listViewImages);
            this.Controls.Add(this.buttonOpenImagesDir);
            this.Controls.Add(this.textBoxImagesDir);
            this.Controls.Add(this.buttonSetImagesDir);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonViewImage);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonRemoveContour);
            this.Controls.Add(this.buttonGenerateContours);
            this.Controls.Add(this.buttonNothing);
            this.Controls.Add(this.buttonEllipse);
            this.Controls.Add(this.buttonTetragon);
            this.Controls.Add(this.buttonTriangle);
            this.Controls.Add(this.buttonLoadImage);
            this.Controls.Add(this.textBoxImagePath);
            this.Controls.Add(this.buttonPolygon);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.textBoxSaveDirPath);
            this.Controls.Add(this.buttonOpenSaveDir);
            this.Controls.Add(this.buttonSetSaveDir);
            this.Controls.Add(this.buttonSaveImage);
            this.Name = "ContourForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contour";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ContourForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContourForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.Button buttonSetSaveDir;
        private System.Windows.Forms.Button buttonOpenSaveDir;
        private System.Windows.Forms.TextBox textBoxSaveDirPath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button buttonPolygon;
        private System.Windows.Forms.TextBox textBoxImagePath;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.Button buttonTriangle;
        private System.Windows.Forms.Button buttonTetragon;
        private System.Windows.Forms.Button buttonEllipse;
        private System.Windows.Forms.Button buttonNothing;
        private System.Windows.Forms.Button buttonGenerateContours;
        private System.Windows.Forms.Button buttonRemoveContour;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonViewImage;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonSetImagesDir;
        private System.Windows.Forms.TextBox textBoxImagesDir;
        private System.Windows.Forms.Button buttonOpenImagesDir;
        private System.Windows.Forms.ListView listViewImages;
    }
}

