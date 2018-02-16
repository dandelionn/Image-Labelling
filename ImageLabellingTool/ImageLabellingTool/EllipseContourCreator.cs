
using System.Drawing;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public class EllipseContourCreator : ContourCreator
    {
        Ellipse _ellipse = new Ellipse();

        public EllipseContourCreator(PictureBox pictureBox)
        {
            _creatingContour = false;
            ContourType = typeof(Ellipse);

            PictureBox = pictureBox;

            AddEvents();
        }

        protected override void AddEvents()
        {
            PictureBox.MouseUp += PictureBox_MouseUp;
            PictureBox.MouseMove += PictureBox_MouseMove;
            PictureBox.MouseDown += PictureBox_MouseDown;
            PictureBox.Paint += PictureBox_Paint;
        }

        public void CreateNewEllipse()
        {
            _creatingContour = true;
            _ellipse = new Ellipse();
        }

        protected override void AddMarker(Point e)
        {
            Point point;

            //Add Center Point
            point = new Point(_selectedRect.X + _selectedRect.Width / 2, _selectedRect.Y + _selectedRect.Height / 2);
            _ellipse.AddMarker(BuildMarker(point));

            //Add Left Point
            point = new Point(_selectedRect.X, _selectedRect.Y + _selectedRect.Height / 2);
            _ellipse.AddMarker(BuildMarker(point));

            //Add Right Point
            point = new Point(_selectedRect.X + _selectedRect.Width, _selectedRect.Y + _selectedRect.Height / 2);
            _ellipse.AddMarker(BuildMarker(point));

            //Add Up Point
            point = new Point(_selectedRect.X + _selectedRect.Width/2, _selectedRect.Y);
            _ellipse.AddMarker(BuildMarker(point));

            //Add Down Point
            point = new Point(_selectedRect.X + _selectedRect.Width/2, _selectedRect.Y + _selectedRect.Height);
            _ellipse.AddMarker(BuildMarker(point));

            _contourMap.AddContour(_ellipse);

            CreateNewEllipse();

            PictureBox.Invalidate();
        }

        private Marker BuildMarker(Point point)
        {
            _marker = new Marker();
            _marker.Parent = PictureBox;
            _marker.Location = new Point(point.X - _marker.Width / 2, point.Y - _marker.Height / 2);

            return _marker;
        }

        public static void DrawContour(Contour contour, PaintEventArgs e)
        {
            (contour as Ellipse).DrawEllipse(e.Graphics);
        }

        protected override void RemoveEvents()
        {
            PictureBox.MouseUp -= PictureBox_MouseUp;
            PictureBox.MouseMove -= PictureBox_MouseMove;
            PictureBox.MouseDown -= PictureBox_MouseDown;
            PictureBox.Paint -= PictureBox_Paint;
        }

        protected override void RemoveUnusedMarkers()
        {
            _creatingContour = false;
            foreach (Marker marker in _ellipse.Markers)
            {
                marker.Dispose();
            }
        }
    }
}
