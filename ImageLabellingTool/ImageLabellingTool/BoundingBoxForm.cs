
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public partial class BoundingBoxForm : Form
    {
        public string _saveDir = string.Empty;
        public string _imagePath = string.Empty;
        public string _imagesDir = string.Empty;

        public void InitialSetup()
        {
            string path = Environment.CurrentDirectory + "\\path.data";
            string image_path = Environment.CurrentDirectory + "\\imagepath.data";
            string imagesDirPath = Environment.CurrentDirectory + "\\imagesDirPath.data";

            if (File.Exists(path))
            {
                try
                {
                    string dir = File.ReadAllLines(path)[0];

                    if (Directory.Exists(dir))
                    {
                        _saveDir = dir;
                        textBoxSaveDirPath.Text = _saveDir;
                    }
                }
                catch (Exception)
                {

                }
            }

            if (File.Exists(imagesDirPath))
            {
                try
                {
                    string dir = File.ReadAllLines(imagesDirPath)[0];

                    if (Directory.Exists(dir))
                    {
                        _imagesDir = dir;
                        textBoxImagesDir.Text = _imagesDir;
                        PopulateImageList(_imagesDir);
                    }
                }
                catch (Exception)
                {

                }
            }

            if (File.Exists(image_path))
            {
                try
                {
                    string fileName = File.ReadAllLines(image_path)[0];

                    if (File.Exists(fileName))
                    {
                        SetImage(fileName);
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void ContourForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(Environment.CurrentDirectory + "\\path.data", _saveDir);
            File.WriteAllText(Environment.CurrentDirectory + "\\imagepath.data", _imagePath);
            File.WriteAllText(Environment.CurrentDirectory + "\\imagesDirPath.data", _imagesDir);
        }

        BoundingBoxCreator boundingBoxCreator;
        public BoundingBoxForm()
        {
            InitializeComponent();
            InitialSetup();

            boundingBoxCreator = new BoundingBoxCreator(pictureBox);
        }

        private void BoundingBoxForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            ChooseImage();
        }

        public void ChooseImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetImage(openFileDialog.FileName);
            }
        }

        private void buttonSetSaveDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _saveDir = folderBrowserDialog.SelectedPath;
                textBoxSaveDirPath.Text = _saveDir;
            }
        }


        private void buttonOpenSaveDir_Click(object sender, EventArgs e)
        {
            if (_saveDir != string.Empty)
            {
                Process.Start(_saveDir);
            }
        }

        public void SetImage(string fileName)
        {
            _imagePath = fileName;
            textBoxImagePath.Text = fileName;

            Image image = Image.FromFile(fileName);

            pictureBox.Size = image.Size;
            pictureBox.Image = image;
        }


        private void buttonViewImage_Click(object sender, EventArgs e)
        {
            if (File.Exists(_imagePath))
            {
                Process.Start(_imagePath);
            }
        }

        private void flowLayoutPanel_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel.Size = new Size(flowLayoutPanel.Width, listBoxImages.Height);
        }

        private void buttonSetImagesDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _imagesDir = folderBrowserDialog.SelectedPath;
                textBoxImagesDir.Text = _imagesDir;

                PopulateImageList(_imagesDir);
            }
        }

        List<string> _imagePaths = new List<string>();

        private void PopulateImageList(string dir)
        {
            listBoxImages.Items.Clear();
            _imagePaths.Clear();

            var paths = Directory.EnumerateFiles(_imagesDir, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                                                                                                            || s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                                                                                                            || s.EndsWith("*.bmp", StringComparison.OrdinalIgnoreCase)
                                                                                                            || s.EndsWith("*.jpeg", StringComparison.OrdinalIgnoreCase));
            foreach (string path in paths)
            {
                listBoxImages.Items.Add(Path.GetFileName(path));
                _imagePaths.Add(path);
            }

            if (_imagePaths.Count > 0)
            {
                listBoxImages.SelectedIndex = 0;
            }
        }

        private void buttonOpenImagesDir_Click(object sender, EventArgs e)
        {
            if (_imagesDir != string.Empty)
            {
                Process.Start(_imagesDir);
            }
        }

        private void listBoxImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetImage(_imagePaths[listBoxImages.SelectedIndex]);
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (listBoxImages.Items.Count > 0)
            {
                if (listBoxImages.SelectedIndex == 0)
                {
                    listBoxImages.SelectedIndex = listBoxImages.Items.Count - 1;
                }
                else
                {
                    listBoxImages.SelectedIndex -= 1;
                }
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (listBoxImages.Items.Count > 0)
            {
                if (listBoxImages.SelectedIndex == listBoxImages.Items.Count - 1)
                {
                    listBoxImages.SelectedIndex = 0;
                }
                else
                {
                    listBoxImages.SelectedIndex += 1;
                }
            }
        }


        private void buttonSaveImageData_Click(object sender, System.EventArgs e)
        {

        }

        private void buttonRemoveBoundingBox_Click(object sender, System.EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, System.EventArgs e)
        {

        }
    }
}