using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public class ContourMap
    {
        public List<Contour> Contours { get; set;}

        private static ContourMap Instance;

        public static ContourMap GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ContourMap();
            }

            return Instance;
        }

        private ContourMap()
        {
            Contours = new List<Contour>();
        }

        public void AddContour(Contour contour)
        {
            foreach (Marker marker in contour.Markers)
            {
                marker.CanBeMoved = true;
            }
            Contours.Add(contour);
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
