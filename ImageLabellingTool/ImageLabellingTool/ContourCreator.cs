using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public abstract class ContourCreator
    {
        public PictureBox PictureBox { get; set; }
        protected ContourMap _contourMap;

        protected Marker _marker;
        protected Type ContourType;

        protected bool _creatingContour;

        protected abstract void AddMarker(Point point);

        public ContourCreator()
        {
            _contourMap = ContourMap.GetInstance();
        }

        public abstract void RemoveUnusedMarkers();

        public void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            AddMarker(new Point(e.X, e.Y));
        }

        public void Marker_MouseClick(object sender, MouseEventArgs e)
        {
             Marker marker = (sender as Marker);
             AddMarker(new Point(marker.Location.X + e.X, marker.Location.Y + e.Y));
            //mouse click scenarios think about them
        }

        public void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (PictureBox.Image != null)
            {
                _contourMap.DrawContours(e);
            }
        }
    }
}
