
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public class TriangleContourCreator: ContourCreator
    {
        Triangle _triangle = new Triangle();
        
        public TriangleContourCreator(PictureBox pictureBox)
        {
            _creatingContour = false;
            ContourType = typeof(Triangle);

            PictureBox = pictureBox;

            AddEvents();
        }

        protected override void AddEvents()
        {
            PictureBox.MouseClick += PictureBox_MouseClick;
            PictureBox.Paint += PictureBox_Paint;
        }

        public void CreateNewTriangle()
        {
            _creatingContour = true;
            _triangle = new Triangle();
        }

       protected override void AddMarker(Point e)
        {
            _marker = new Marker();
            _marker.Parent = PictureBox;
            _marker.Location = new Point(e.X - _marker.Width / 2, e.Y - _marker.Height / 2);
            _marker.MouseClick += Marker_MouseClick;

            _triangle.AddMarker(_marker);


            if (_triangle.Markers.Count == 3)
            {
                _triangle.AddMarker(_triangle.Markers[0]);


                foreach (Marker marker in _triangle.Markers)
                {
                    marker.MouseClick -= Marker_MouseClick;
                }

                _contourMap.AddContour(_triangle);

                CreateNewTriangle(); //allows the creation of a new triangle after a triangle has been defined
            }

            PictureBox.Invalidate();
        }

        public static void DrawContour(Contour contour, PaintEventArgs e)
        {
            (contour as Triangle).DrawLines(e.Graphics);
        }

        protected override void RemoveEvents()
        {
            PictureBox.MouseClick += PictureBox_MouseClick;
            PictureBox.Paint += PictureBox_Paint;
        }

        protected override void RemoveUnusedMarkers()
        {
            _creatingContour = false;
            foreach (Marker marker in _triangle.Markers)
            {
                marker.Dispose();
            }
        }
    }
}
