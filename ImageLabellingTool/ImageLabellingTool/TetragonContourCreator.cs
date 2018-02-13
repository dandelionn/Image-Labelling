﻿using System.Drawing;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public class TetragonContourCreator: ContourCreator
    {
        Tetragon _tetragon = new Tetragon();

        public TetragonContourCreator()
        {
            _creatingContour = false;
            ContourType = typeof(Tetragon);
        }

        public void CreateNewTetragon()
        {
            _creatingContour = true;
            _tetragon = new Tetragon();
        }

        protected override void AddMarker(Point e)
        {
            _marker = new Marker();
            _marker.Parent = PictureBox;
            _marker.Location = new Point(e.X - _marker.Width / 2, e.Y - _marker.Height / 2);
            _marker.MouseClick += Marker_MouseClick;

            _tetragon.AddMarker(_marker);

            if (_tetragon.Markers.Count == 4)
            {
                _tetragon.AddMarker(_tetragon.Markers[0]);

                foreach(Marker marker in _tetragon.Markers)
                {
                    marker.MouseClick -= Marker_MouseClick;
                }

                _contourMap.AddContour(_tetragon);


                CreateNewTetragon();
            }

            PictureBox.Invalidate();
        }

        public static void DrawContour(Contour contour, PaintEventArgs e)
        {
            (contour as Tetragon).DrawLines(e.Graphics);
        }

        public override void RemoveUnusedMarkers()
        {
            _creatingContour = false;
            foreach (Marker marker in _tetragon.Markers)
            {
                marker.Dispose();
            }
        }
    }
}
