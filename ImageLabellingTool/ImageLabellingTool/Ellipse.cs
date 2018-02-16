using System;
using System.Drawing;

namespace ImageLabellingTool
{
    public class Ellipse: Contour
    {
        float x, y;
        int xc, yc;
        Pen _pen;

        public Ellipse()
        {
            _pen = new Pen(Brushes.Red);
            ContourType = this.GetType();

        }

        public new void AddMarker(Marker marker)
        {
            Markers.Add(marker);
        }

        public void DrawEllipse(Graphics e)
        {
            int a, b;  //ellipse parameters

            double p1, p2;

            Point center = Markers[0].CenterPosition;
            xc = center.X;
            yc = center.Y;

            a = Math.Abs(Markers[1].CenterPosition.X - Markers[2].CenterPosition.X) / 2;
            b = Math.Abs(Markers[3].CenterPosition.Y - Markers[4].CenterPosition.Y) / 2;

            x = 0; y = b;
            SetPixels(e);
            p1 = (b * b) - (a * a * b) + (a * a) / 4;

            while ((2.0 * b * b * x) <= (2.0 * a * a * y))
            {
                x++;
                if (p1 <= 0)
                {
                    p1 = p1 + (2.0 * b * b * x) + (b * b);
                }
                else
                {
                    y--;
                    p1 = p1 + (2.0 * b * b * x) + (b * b) - (2.0 * a * a * y);
                }
                SetPixels(e);
                x = -x;
                SetPixels(e);
                x = -x;
            }

            x = a;
            y = 0;
            SetPixels(e);
            p2 = (a * a) + 2.0 * (b * b * a) + (b * b) / 4;
            while ((2.0 * b * b * x) > (2.0 * a * a * y))
            {
                y++;
                if (p2 > 0)
                {
                    p2 = p2 + (a * a) - (2.0 * a * a * y);
                }
                else
                {
                    x--;
                    p2 = p2 + (2.0 * b * b * x) - (2.0 * a * a * y) + (a * a);
                }
                SetPixels(e);
                y = -y;
                SetPixels(e);
                y = -y;
            }
        }

        public void SetPixels(Graphics e)
        {
            e.FillRectangle(Brushes.Red, xc + x, yc + y, 1, 1);
            e.FillRectangle(Brushes.Red, xc - x, yc + y, 1, 1);
            e.FillRectangle(Brushes.Red, xc + x, yc - y, 1, 1);
            e.FillRectangle(Brushes.Red, xc + x, yc - y, 1, 1);
        }
    }
}
