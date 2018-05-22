using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public partial class ContourForm : Form
    {
        public string _saveDir = string.Empty;
        public string _imagePath = string.Empty;
        public string _imagesDir = string.Empty;

        PictureBox _pictureBox = null;

        HashSet<string> ImageProccessed;

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

                        RegisterProccessedImages();
                        ApplyHighlights();

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

            if (_extractedContoursForm != null)
            {
                _extractedContoursForm.Close();
            }

            _contourMap.Clear();
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
        
        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            GenerateContours();
            if (_pictureBox != null && _extractedContoursForm != null)
            {
                if (_pictureBox.Image != null && _extractedContoursForm.pictureBox.Image != null)
                {
                    if (Directory.Exists(textBoxSaveDirPath.Text))
                    {

                        _extractedContoursForm.pictureBox.Image.Save(Path.Combine(_saveDir, Path.GetFileName(_imagePath)));
                        ImageProccessed.Add(Path.GetFileName(_imagePath));
                        SaveContour();
                        ApplyHighlights();
                    }
                    else
                    {
                        MessageBox.Show("Save directory not valid");
                    }
                }
            }
        }

        private void SaveContour()
        {
            string path = Path.Combine(_saveDir, Path.GetFileNameWithoutExtension(_imagePath) + ".txt");

            using(StreamWriter streamWriter = new StreamWriter(path))
            {
                foreach (Contour contour in _contourMap.Contours)
                {
                    streamWriter.Write(contour.ContourType.ToString().Substring(contour.ContourType.ToString().LastIndexOf('.') + 1) + " ");
                    foreach (Marker marker in contour.Markers)
                    {
                        streamWriter.Write(marker.Location.X.ToString() + " " + marker.Location.Y.ToString() + " ");
                    }

                    streamWriter.WriteLine();
                }
            }
        }

        private void buttonSetSaveDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _saveDir = folderBrowserDialog.SelectedPath;
                textBoxSaveDirPath.Text = _saveDir;

                RegisterProccessedImages();
                ApplyHighlights();
            }
        }

        private void ApplyHighlights()
        {
            if (_saveDir != string.Empty && _imagesDir != string.Empty)
            {
                Graphics graphics = listViewImages.CreateGraphics();
                for(int i=0; i < listViewImages.Items.Count; i++)
                {
                    Rectangle rectangle = listViewImages.Items[i].Bounds;

                    if (ImageProccessed.Contains(listViewImages.Items[i].Text))
                    {                    
                        graphics.FillRectangle(Brushes.Orange, rectangle);
                    }
                    else
                    {
                        graphics.FillRectangle(new SolidBrush(listViewImages.BackColor), rectangle);
                    }

                    TextRenderer.DrawText(graphics, listViewImages.Items[i].Text, listViewImages.Font, rectangle, listViewImages.ForeColor);
                }
            }
        }

        public void RegisterProccessedImages()
        {
            ImageProccessed.Clear();
            var paths = Directory.EnumerateFiles(_saveDir, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                                                                                                            || s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                                                                                                            || s.EndsWith("*.bmp", StringComparison.OrdinalIgnoreCase)
                                                                                                            || s.EndsWith("*.jpeg", StringComparison.OrdinalIgnoreCase));
            foreach(string path in paths)
            {
                ImageProccessed.Add(Path.GetFileName(path));
            }
        }

        private void buttonOpenSaveDir_Click(object sender, EventArgs e)
        {
            if (_saveDir != string.Empty)
            {
                Process.Start(_saveDir);
            }
        }

        public ContourForm()
        {
            InitializeComponent();
            _contourMap = ContourMap.GetInstance(_pictureBox);
            _contourMapGenerator = ContourMapGenerator.GetInstance(_pictureBox);
            ImageProccessed = new HashSet<string>();

            InitialSetup();
        }

        ContourMapGenerator _contourMapGenerator;
        ContourMap _contourMap;
        ContourOperator _contourOperator;
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

            if (_contourOperator != null)
            {
                _contourOperator.RemoveResources();
            }

            if (_pictureBox != null)
            {
                _contourOperator = new Nothing(_pictureBox);
            }
        }

        private void buttonPolygon_Click(object sender, EventArgs e)
        {
            DeEmphasizeButton();
            EmphasizeButton(sender as Button);

            if (_contourOperator != null)
            {
                _contourOperator.RemoveResources();
            }

            if (_pictureBox != null)
            {
                _contourOperator = new PolygonContourCreator(_pictureBox);
            }
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            DeEmphasizeButton();
            EmphasizeButton(sender as Button);

            if (_contourOperator != null)
            {
                _contourOperator.RemoveResources();
            }

            if (_pictureBox != null)
            {
                _contourOperator = new TriangleContourCreator(_pictureBox);
            }
        }

        private void buttonTetragon_Click(object sender, EventArgs e)
        {
            DeEmphasizeButton();
            EmphasizeButton(sender as Button);

            if (_contourOperator != null)
            {
                _contourOperator.RemoveResources();
            }

            if (_pictureBox != null)
            {
                _contourOperator = new TetragonContourCreator(_pictureBox); ;
            }
        }

        private void buttonEllipse_Click(object sender, EventArgs e)
        {
            DeEmphasizeButton();
            EmphasizeButton(sender as Button);

            if (_contourOperator != null)
            {
                _contourOperator.RemoveResources();
            }

            if (_pictureBox != null)
            {
                _contourOperator = new EllipseContourCreator(_pictureBox);
            }
        }

        public void SetImage(string fileName)
        {
            _contourMap.Clear();
            if (_pictureBox == null)
            {
                _pictureBox = new PictureBox();
                _pictureBox.Parent = flowLayoutPanel;
                _pictureBox.Margin = new Padding(0, 0, 0, 0);
                _pictureBox.Location = new Point(0, 0);
            }

            _imagePath = fileName;
            textBoxImagePath.Text = fileName;

            Image image = Image.FromFile(fileName);

            _pictureBox.Size = image.Size;
            _pictureBox.Image = image;
        }

        PictureBox _pictureBoxContour = new PictureBox();
        ExtractedContoursForm _extractedContoursForm;
        private void buttonGenerateContours_Click(object sender, EventArgs e)
        {
            GenerateContours();
        }

        private void GenerateContours()
        {
            if (_contourMap.Contours.Count > 0)
            {
                Bitmap image = new Bitmap(_imagePath);
                Bitmap contourImage = _contourMapGenerator.GenerateContourImage(image, _contourMap.Contours);

                if (_extractedContoursForm == null)
                {
                    _extractedContoursForm = new ExtractedContoursForm(contourImage);
                    _extractedContoursForm.Disposed += _extractedContoursForm_Disposed;
                    _extractedContoursForm.Show();
                }
                else
                {
                    _extractedContoursForm.SetImage(contourImage);
                }
            }
        }

        private void buttonRemoveContour_Click(object sender, EventArgs e)
        {
            DeEmphasizeButton();
            EmphasizeButton(sender as Button);

            if (_contourOperator != null)
            {
                _contourOperator.RemoveResources();
            }

            if (_pictureBox != null)
            {
                _contourOperator = new ContourRemover(_pictureBox);
            }
        }

        private void _extractedContoursForm_Disposed(object sender, EventArgs e)
        {
            _extractedContoursForm = null;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            DeEmphasizeButton();
            EmphasizeButton(sender as Button);

            if (_contourOperator != null)
            {
                _contourOperator.RemoveResources();
            }

            if (_pictureBox != null)
            {
                _contourOperator = new ContourRemover(_pictureBox);
                (_contourOperator as ContourRemover).Clear();
            }
        }

        private void buttonViewImage_Click(object sender, EventArgs e)
        {
            if(File.Exists(_imagePath))
            {
                Process.Start(_imagePath);
            }
        }

        private void flowLayoutPanel_SizeChanged(object sender, EventArgs e)
        {

        }

        private void buttonSetImagesDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _imagesDir = folderBrowserDialog.SelectedPath;
                textBoxImagesDir.Text = _imagesDir;

                PopulateImageList(_imagesDir);
                ApplyHighlights();
            }
        }

        List<string> _imagePaths = new List<string>();
        List<Contour> _contours = new List<Contour>();

        private void PopulateImageList(string dir)
        {
            listViewImages.Items.Clear();
            _imagePaths.Clear();

            var paths = Directory.EnumerateFiles(_imagesDir, "*.*", SearchOption.TopDirectoryOnly).Where(s  =>  s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) 
                                                                                                            ||  s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) 
                                                                                                            ||  s.EndsWith("*.bmp", StringComparison.OrdinalIgnoreCase) 
                                                                                                            ||  s.EndsWith("*.jpeg", StringComparison.OrdinalIgnoreCase));

            foreach(string path in paths)
            {
                listViewImages.Items.Add(Path.GetFileName(path));
                _imagePaths.Add(path);
            }

            if(_imagePaths.Count > 0)
            {
                listViewImages.Items[0].Selected = true;
                _imagePath = _imagePaths[0];
            }
        }

        private void buttonOpenImagesDir_Click(object sender, EventArgs e)
        {
            if (_imagesDir != string.Empty)
            {
                Process.Start(_imagesDir);
            }
        }

        private void listViewImages_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewImages.SelectedIndices.Count > 0)
            {
                SetImage(_imagePaths[listViewImages.SelectedIndices[0]]);
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (listViewImages.Items.Count > 0)
            {
                if (listViewImages.SelectedIndices[0] == 0)
                {
                    listViewImages.Items[listViewImages.Items.Count - 1].Selected = true;
                }
                else
                {
                    listViewImages.Items[listViewImages.SelectedIndices[0] - 1].Selected = true;
                }
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (listViewImages.Items.Count > 0)
            {
                if (listViewImages.SelectedIndices[0] == listViewImages.Items.Count - 1)
                {
                    listViewImages.Items[0].Selected = true;
                }
                else  
                {
                    listViewImages.Items[listViewImages.SelectedIndices[0] + 1].Selected = true;
                }
            }
        }

        private void listViewImages_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (e.Item.Selected == true)
            {
                e.Graphics.FillRectangle(Brushes.Yellow, e.Bounds);
                e.DrawText(TextFormatFlags.TextBoxControl);
            }
            else
            {
                if (ImageProccessed.Contains(e.Item.Text))
                {
                    e.Graphics.FillRectangle(Brushes.Orange, e.Bounds);
                    e.DrawText(TextFormatFlags.TextBoxControl);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(listViewImages.BackColor), e.Bounds);
                    e.DrawText(TextFormatFlags.TextBoxControl);
                }
            }
        }

        private void listViewImages_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel.Size = new Size(flowLayoutPanel.Width, listViewImages.Height);
        }
    }
}
