using ImageLabellingTool;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageCropper
{
    public partial class ContourForm : Form
    {
        long indexRectangle = 0;
        long indexEllipse = 0;
        long indexTriangle = 0;
        long indexCircle = 0;
        long indexSquare = 0;

        public string _saveDir = string.Empty;
        PictureBox _pictureBox = null;
        string _currentCropType = string.Empty;

        public void InitialSetup()
        {
            buttonCropRectangle_Click(null, null);

            string path = Environment.CurrentDirectory + "\\path.data";

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
                catch(Exception)
                {

                }
            }   
        }

        public ContourForm()
        {
            InitializeComponent();
            InitialSetup();
        }

        public void SetImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (_pictureBox == null)
                {
                    _pictureBox = new PictureBox();
                    _pictureBox.MouseDown += pictureBox_MouseDown;
                    _pictureBox.MouseMove += pictureBox_MouseMove;
                    _pictureBox.MouseUp += pictureBox_MouseUp;

                    _pictureBox.MouseClick += pictureBox_MouseClick;

                    _pictureBox.Paint += pictureBox_Paint;
                  
                    _pictureBox.Parent = flowLayoutPanel;
                    
                }
                Image image = Image.FromFile(openFileDialog.FileName);

                _pictureBox.Size = image.Size;
                _pictureBox.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private Point[] _polygonPoints;
        private Point _rectStartPoint;
        private Rectangle _selectedRect = new Rectangle();
        private Brush _selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));



        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;


            _selectedRect = ComputeRectInfo(e.Location);

            labelCropSize.Text = _selectedRect.Size.Width.ToString() + " x " + _selectedRect.Size.Height.ToString();

            //_pictureBox.Invalidate();
        }

        public Rectangle ComputeRectInfo(Point tempEndPoint)
        {
            Rectangle rectangle = new Rectangle();

            switch (_currentCropType)
            {
                case "triangle":
                    rectangle.Location = new Point(Math.Min(_rectStartPoint.X, tempEndPoint.X), Math.Min(_rectStartPoint.Y, tempEndPoint.Y));
                    rectangle.Size = new Size(Math.Abs(_rectStartPoint.X - tempEndPoint.X), Math.Abs(_rectStartPoint.Y - tempEndPoint.Y));

                    _polygonPoints = new Point[3];
                    _polygonPoints[0] = new Point(_selectedRect.Location.X + _selectedRect.Width / 2, _selectedRect.Location.Y);
                    _polygonPoints[1] = new Point(_selectedRect.Location.X + _selectedRect.Width, _selectedRect.Location.Y + _selectedRect.Height);
                    _polygonPoints[2] = new Point(_selectedRect.Location.X, _selectedRect.Location.Y + _selectedRect.Height);
                    break;

                case "ellipse":
                    rectangle.Location = new Point(Math.Min(_rectStartPoint.X, tempEndPoint.X), Math.Min(_rectStartPoint.Y, tempEndPoint.Y));
                    rectangle.Size = new Size(Math.Abs(_rectStartPoint.X - tempEndPoint.X), Math.Abs(_rectStartPoint.Y - tempEndPoint.Y));
                    break;

                case "square":
                    rectangle.Location = new Point(Math.Min(_rectStartPoint.X, tempEndPoint.X), Math.Min(_rectStartPoint.Y, tempEndPoint.Y));
                    rectangle.Size = new Size(Math.Abs(_rectStartPoint.Y - tempEndPoint.Y), Math.Abs(_rectStartPoint.Y - tempEndPoint.Y));
                    break;

                case "circle":
                    rectangle.Location = new Point(Math.Min(_rectStartPoint.X, tempEndPoint.X), Math.Min(_rectStartPoint.Y, tempEndPoint.Y));
                    rectangle.Size = new Size(Math.Abs(_rectStartPoint.Y - tempEndPoint.Y), Math.Abs(_rectStartPoint.Y - tempEndPoint.Y));
                    break;

                case "rectangle":
                    rectangle.Location = new Point(Math.Min(_rectStartPoint.X, tempEndPoint.X), Math.Min(_rectStartPoint.Y, tempEndPoint.Y));
                    rectangle.Size = new Size(Math.Abs(_rectStartPoint.X - tempEndPoint.X), Math.Abs(_rectStartPoint.Y - tempEndPoint.Y));
                    break;
            }
        
            return rectangle;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (_pictureBox.Image != null)
            {
                if (_selectedRect != null && _selectedRect.Width > 0 && _selectedRect.Height > 0)
                {
                    switch (_currentCropType)
                    {
                        case "triangle":
                            e.Graphics.FillPolygon(_selectionBrush, _polygonPoints);
                            break;

                        case "ellipse":
                            e.Graphics.FillEllipse(_selectionBrush, _selectedRect);
                            break;

                        case "square":
                            e.Graphics.FillRectangle(_selectionBrush, _selectedRect);
                            break;

                        case "circle":
                            e.Graphics.FillEllipse(_selectionBrush, _selectedRect);
                            break;

                        case "rectangle":
                            e.Graphics.FillRectangle(_selectionBrush, _selectedRect);
                            break;
                    }
                    
                }
                if (_polygon != null)
                {
                    e.Graphics.DrawLine(new Pen(Color.Red), new Point(x, 140), new Point(120,400));
                    _polygon.DrawLines(e.Graphics);
                    x += 20;
                }
            }
        }
        int x = 120;



        public Bitmap crop_polygon(Image image, Rectangle cropRectangle, Point[] polygonPoints)
        {
            Point[] points = new Point[polygonPoints.Length];
            for(int i=0; i < polygonPoints.Length; i++)
            {
                points[i] = new Point(polygonPoints[i].X - cropRectangle.X, polygonPoints[i].Y - cropRectangle.Y);
            }

            Bitmap sourceImage = new Bitmap(image);

            Bitmap croppedImage = sourceImage.Clone(cropRectangle, sourceImage.PixelFormat);

            TextureBrush textureBrush = new TextureBrush(croppedImage);

            Bitmap finalImage = new Bitmap(cropRectangle.Width, cropRectangle.Height);

            Graphics g = Graphics.FromImage(finalImage);
            g.FillPolygon(textureBrush, points);

            return finalImage;
        }

        public Bitmap crop_rectangle(Image image, Rectangle cropRectangle)
        {
            Bitmap sourceImage = new Bitmap(image);

            Bitmap croppedImage = sourceImage.Clone(cropRectangle, sourceImage.PixelFormat);

            return croppedImage;
        }

        public Bitmap crop_ellipse(Image image, Rectangle cropRectangle)
        {
            Bitmap sourceImage = new Bitmap(image);

            Bitmap croppedImage = sourceImage.Clone(cropRectangle, sourceImage.PixelFormat);

            TextureBrush textureBrush = new TextureBrush(croppedImage);

            Bitmap finalImage = new Bitmap(cropRectangle.Width, cropRectangle.Height);

            Graphics g = Graphics.FromImage(finalImage);
            g.FillEllipse(textureBrush, 0, 0, cropRectangle.Width, cropRectangle.Height);

            return finalImage;
        }

        public Bitmap crop_ellipse(string sourceFile, Rectangle cropRectangle)
        {
            Bitmap sourceImage = new Bitmap(Image.FromFile(sourceFile));

            Bitmap croppedImage = sourceImage.Clone(cropRectangle, sourceImage.PixelFormat);

            TextureBrush textureBrush = new TextureBrush(croppedImage);

            Bitmap finalImage = new Bitmap(cropRectangle.Width, cropRectangle.Height);

            Graphics g = Graphics.FromImage(finalImage);
            g.FillEllipse(textureBrush, 0, 0, cropRectangle.Width, cropRectangle.Height);

            return finalImage;
        }

        private void buttonOpenImage_Click(object sender, EventArgs e)
        {
            SetImage();
        }

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            if (_pictureBox.Image != null)
            {
                if (_selectedRect != null && _selectedRect.Width > 0 && _selectedRect.Height > 0)
                {
                    Bitmap image = null;
                    switch (_currentCropType)
                    {
                        case "triangle":
                            image = crop_polygon(_pictureBox.Image, _selectedRect, _polygonPoints);
                        break;

                        case "ellipse":
                            image = crop_ellipse(_pictureBox.Image, _selectedRect);
                            break;

                        case "square":
                            image = crop_rectangle(_pictureBox.Image, _selectedRect);
                            break;

                        case "circle":
                            image = crop_ellipse(_pictureBox.Image, _selectedRect);
                            break;

                        case "rectangle":
                            image = crop_rectangle(_pictureBox.Image, _selectedRect);
                            break;
                    }

                    if (image != null)
                    {
                        SaveImage(image, _currentCropType);
                    }
                }
            }
        }

        public void SaveImage(Bitmap bmp, string name)
        {
            if (Directory.Exists(_saveDir))
            {
                string filePath = Path.Combine(_saveDir, name);
                switch (name)
                {
                    case "ellipse":
                        {
                            while(File.Exists(filePath + indexEllipse + ".png"))
                            {
                                indexEllipse++;
                            }

                            filePath += indexEllipse + ".png";
                        }
                        break;

                    case "rectangle":
                        {
                            while (File.Exists(filePath + indexRectangle + ".png"))
                            {
                                indexRectangle++;
                            }

                            filePath += indexRectangle + ".png";
                        }
                        break;

                    case "triangle":
                        {
                            while (File.Exists(filePath + indexTriangle + ".png"))
                            {
                                indexTriangle++;
                            }

                            filePath += indexTriangle + ".png";
                        }
                        break;

                    case "circle":
                        {
                            while (File.Exists(filePath + indexCircle + ".png"))
                            {
                                indexCircle++;
                            }

                            filePath += indexCircle + ".png";
                        }
                        break;

                    case "square":
                        {
                            while (File.Exists(filePath + indexSquare + ".png"))
                            {
                                indexSquare++;
                            }

                            filePath += indexSquare + ".png";
                        }
                        break;
                }

                bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void buttonSetSaveDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _saveDir = folderBrowserDialog.SelectedPath;
                textBoxSaveDirPath.Text = _saveDir;
            }
        }

        private void buttonOpenSaveDir_Click(object sender, EventArgs e)
        {
            Process.Start(_saveDir);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(Environment.CurrentDirectory + "\\path.data", _saveDir);
        }

        public void ResetCropButtonColor(string name)
        {
            switch(name)
            {
                case "triangle":
                    buttonCropTriangle.BackColor = Color.White;
                    break;

                case "ellipse":
                    buttonCropEllipse.BackColor = Color.White;
                    break;

                case "square":
                    buttonCropSquare.BackColor = Color.White;
                    break;

                case "circle":
                    buttonCropCircle.BackColor = Color.White;
                    break;

                case "rectangle":
                    buttonCropRectangle.BackColor = Color.White;
                    break;
            }
        }

        private void buttonCropTriangle_Click(object sender, EventArgs e)
        {
            ResetCropButtonColor(_currentCropType);
            _currentCropType = "triangle";
            buttonCropTriangle.BackColor = Color.Yellow;
        }

        private void buttonCropEllipse_Click(object sender, EventArgs e)
        {
            ResetCropButtonColor(_currentCropType);
            _currentCropType = "ellipse";
            buttonCropEllipse.BackColor = Color.Yellow;
        }

        private void buttonCropRectangle_Click(object sender, EventArgs e)
        {
            ResetCropButtonColor(_currentCropType);
            _currentCropType = "rectangle";
            buttonCropRectangle.BackColor = Color.Yellow;
        }

        private void buttonCropSquare_Click(object sender, EventArgs e)
        {
            ResetCropButtonColor(_currentCropType);
            _currentCropType = "square";
            buttonCropSquare.BackColor = Color.Yellow;
        }

        private void buttonCropCircle_Click(object sender, EventArgs e)
        {
            ResetCropButtonColor(_currentCropType);
            _currentCropType = "circle";
            buttonCropCircle.BackColor = Color.Yellow;
        }

        private void ContourForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void ContourForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _rectStartPoint = e.Location;
            //Invalidate();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (_selectedRect.Contains(e.Location))
                {
                    Debug.WriteLine("Right click");
                }
            }
        }

        Marker _marker;
        Polygon _polygon = new Polygon();
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if(buttonPolygonPressed == true)
            {
                _marker = new Marker();
                _marker.Parent = _pictureBox;
                _marker.Location = new Point(e.X - _marker.Width / 2, e.Y - _marker.Height / 2);
                //_marker.Show();

                if(_polygon.AddMarker(_marker))
                {
                    buttonPolygonPressed = false;
                }

                //Invalidate();
            }
        }

        List<Marker> markers = new List<Marker>();

        bool buttonPolygonPressed = false;
        private void buttonPolygon_Click(object sender, EventArgs e)
        {
            buttonPolygonPressed = true;
        }

        private void ContourForm_MouseClick(object sender, MouseEventArgs e)
        {
            AddMarker(new Point(e.X,e.Y));
        }

        private void AddMarker(Point e)
        {
            if (buttonPolygonPressed == true)
            {
                _marker = new Marker();
                _marker.Parent = this;
                _marker.Location = new Point(e.X - _marker.Width / 2, e.Y - _marker.Height / 2);
                _marker.MouseClick += _marker_MouseClick;
                //_marker.Show();

                if (_polygon.AddMarker(_marker))
                {
                    buttonPolygonPressed = false;

                    _marker.Dispose();
                }

                Invalidate();
            }
        }

        private void _marker_MouseClick(object sender, MouseEventArgs e)
        {
            Marker marker = (sender as Marker);
            AddMarker(new Point(marker.Location.X + e.X, marker.Location.Y + e.Y));
        }

        private void ContourForm_Paint(object sender, PaintEventArgs e)
        {
            _polygon.DrawLines(e.Graphics);
        }

        public void IsPointOutsideContour(Point point, List<Marker> markers)
        {
            for(int i=0; i < markers.Count-1; i++)
            {
               // if()
            }
        }
    }
}
