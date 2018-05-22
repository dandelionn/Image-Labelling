using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public class ContourMap
    {
        public List<Contour> Contours { get; set;}

        ContourMapGenerator _contourMapGenerator;

        private static ContourMap Instance;

        public static ContourMap GetInstance(PictureBox pictureBox)
        {
            if (Instance == null)
            {
                Instance = new ContourMap(pictureBox);
            }

            return Instance;
        }

        private ContourMap(PictureBox pictureBox)
        {
            Contours = new List<Contour>();
            _contourMapGenerator = ContourMapGenerator.GetInstance(pictureBox);
        }

        public void AddContour(Contour contour)
        {
            foreach (Marker marker in contour.Markers)
            { 
                marker.Contour = contour;
                marker.CanBeMoved = true; 
            }
            Contours.Add(contour);
        }

        public void RemoveContour(Contour contour)
        {
            while (contour.Markers.Count != 0)
            {
                contour.Markers[0].Dispose();
                contour.Markers.RemoveAt(0);
            }

            Contours.Remove(contour);

            if (Contours.Count == 0)
            {
                _contourMapGenerator.HideInsidePoint();
            }
        }

        public void Clear()
        {
            foreach (Contour contour in Contours)
            {
                while (contour.Markers.Count != 0)
                {
                    contour.Markers[0].Dispose();
                    contour.Markers.RemoveAt(0);
                }
            }

            Contours.Clear();

            if (Contours.Count == 0)
            {
                _contourMapGenerator.HideInsidePoint();
            }
        }

        public void DrawContours(PaintEventArgs e)
        {
            foreach (Contour contour in Contours)
            {
                if (contour is Triangle)
                {
                    TriangleContourCreator.DrawContour(contour, e);
                    continue;
                }
                if (contour is Polygon)
                {
                    PolygonContourCreator.DrawContour(contour, e);
                    continue;
                }
                if (contour is Tetragon)
                {
                    TetragonContourCreator.DrawContour(contour, e);
                    continue;
                }
                if (contour is Ellipse)
                {
                    EllipseContourCreator.DrawContour(contour, e);
                }
            }
        }
    }
}
