using ImageLabellingTool;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ImageCropper
{
    public partial class ContourForm : Form
    {
        public string _saveDir = string.Empty;
        public string _imagePath = string.Empty;

        PictureBox _pictureBox = null;

        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();


        public void InitialSetup()
        {
            string path = Environment.CurrentDirectory + "\\path.data";
            string image_path = Environment.CurrentDirectory + "\\imagepath.data";

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
        }

        private void ContourForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        public void ChooseImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetImage(openFileDialog.FileName);
            }
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            ChooseImage();
        }

        private void buttonOpenImage_Click(object sender, EventArgs e)
        {

        }

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            if (_pictureBox.Image != null)
            {

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
            if (_saveDir != "")
            {
                Process.Start(_saveDir);
            }
        }

        public ContourForm()
        {
            AllocConsole();
            InitializeComponent();
            InitialSetup();

            _contourMap = ContourMap.GetInstance();
            _contourMapGenerator = new ContourMapGenerator();
        }

        ContourMapGenerator _contourMapGenerator;
        ContourMap _contourMap;
        ContourCreator _contourCreator;
        Button _currentPressedButton;
        public void EmphasizeButton(Button button)
        {
            button.BackColor = Color.YellowGreen;
            _currentPressedButton = button;
        }

        public void DeEmphasizeButton()
        {
            if (_currentPressedButton != null)
            {
                _currentPressedButton.BackColor = Color.White;
            }
        }

        private void buttonNothing_Click(object sender, EventArgs e)
        {
            DeEmphasizeButton();
            EmphasizeButton(sender as Button);

            if (_contourCreator != null)
            {
                _contourCreator.RemoveResources();
            }

            _contourCreator = null;
        }

        private void buttonPolygon_Click(object sender, EventArgs e)
        {
            DeEmphasizeButton();
            EmphasizeButton(sender as Button);

            if (_contourCreator != null)
            {
                _contourCreator.RemoveResources();
            }

            if (_pictureBox != null)
            {
                _contourCreator = new PolygonContourCreator(_pictureBox);
            }
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            DeEmphasizeButton();
            EmphasizeButton(sender as Button);

            if (_contourCreator != null)
            {
                _contourCreator.RemoveResources();
            }

            if (_pictureBox != null)
            {
                _contourCreator = new TriangleContourCreator(_pictureBox);
            }
        }

        private void buttonTetragon_Click(object sender, EventArgs e)
        {
            DeEmphasizeButton();
            EmphasizeButton(sender as Button);

            if (_contourCreator != null)
            {
                _contourCreator.RemoveResources();
            }

            if (_pictureBox != null)
            {
                _contourCreator = new TetragonContourCreator(_pictureBox); ;
            }
        }

        private void buttonEllipse_Click(object sender, EventArgs e)
        {
            DeEmphasizeButton();
            EmphasizeButton(sender as Button);

            if (_contourCreator != null)
            {
                _contourCreator.RemoveResources();
            }

            if (_pictureBox != null)
            {
                _contourCreator = new EllipseContourCreator(_pictureBox);
            }
        }

        public void SetImage(string fileName)
        {
            if (_pictureBox == null)
            {
                _pictureBox = new PictureBox();
                _pictureBox.Parent = flowLayoutPanel;
            }

            _imagePath = fileName;
            textBoxImagePath.Text = fileName;

            Image image = Image.FromFile(fileName);

            _pictureBox.Size = image.Size;
            _pictureBox.Image = image;
        }

        PictureBox _pictureBoxContour = new PictureBox();
        private void buttonGenerateContours_Click(object sender, EventArgs e)
        {
            if (_contourMap.Contours.Count > 0)
            {
                Bitmap image = new Bitmap(_imagePath);
                Bitmap contourImage = _contourMapGenerator.GenerateContourImage(image, _contourMap.Contours);

            
               
                _pictureBoxContour.Parent = flowLayoutPanelContour;


                _pictureBoxContour.Size = image.Size;
                _pictureBoxContour.Image = contourImage;
            }
        }
    }
}
