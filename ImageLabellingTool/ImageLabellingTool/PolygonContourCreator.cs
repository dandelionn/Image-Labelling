
using System.Drawing;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public class PolygonContourCreator: ContourCreator
    {
        Polygon _polygon = new Polygon();

        public PolygonContourCreator(PictureBox pictureBox)
        {
            ContourType = typeof(Polygon);

            PictureBox = pictureBox;
            AddEvents();
        }

        protected override void AddEvents()
        {
            PictureBox.MouseClick += PictureBox_MouseClick;
            PictureBox.Paint += PictureBox_Paint;
        }

        public void CreateNewPolygon()
        {
            _creatingContour = false;
            _polygon = new Polygon();
        }

        protected override void AddMarker(Point e)
        {
            _marker = new Marker();
            _marker.Parent = PictureBox;
            _marker.Location = new Point(e.X - _marker.Width / 2, e.Y - _marker.Height / 2);
            _marker.MouseClick += Marker_MouseClick;

            if (_polygon.AddMarker(_marker))
            {
                _marker.Dispose();

                foreach (Marker marker in _polygon.Markers)
                {
                    marker.MouseClick -= Marker_MouseClick;
                }

                _contourMap.AddContour(_polygon);

                CreateNewPolygon();
            }

            PictureBox.Invalidate();
        }

        public static void DrawContour(Contour contour, PaintEventArgs e)
        {
            (contour as Polygon).DrawLines(e.Graphics);
        }

        protected override void RemoveEvents()
        {
            PictureBox.MouseClick += PictureBox_MouseClick;
            PictureBox.Paint += PictureBox_Paint;
        }

        protected override void RemoveUnusedMarkers()
        {
            foreach(Marker marker in _polygon.Markers)
            {
                marker.Dispose();
            }
        }
    }
}
