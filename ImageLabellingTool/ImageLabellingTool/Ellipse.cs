using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace ImageLabellingTool
{
    public class Ellipse : Contour
    {
        public Ellipse()
        {
            ContourType = this.GetType();
        }

        public new void AddMarker(Marker marker)
        {
            Markers.Add(marker);
        }

        float x, y;
        double angle;
        int xc, yc;
        Point _center;

        public void DrawEllipse(Graphics e)
        {
            int a, b;  //ellipse parameters

            double p1, p2;

            _center = Markers[0].CenterPosition;
            xc = _center.X;
            yc = _center.Y;

            a = (int) Math.Round(Geometry.EuclidianDistance(Markers[1].CenterPosition, Markers[2].CenterPosition)) / 2;
            b = (int) Math.Round(Geometry.EuclidianDistance(Markers[3].CenterPosition, Markers[4].CenterPosition)) / 2;
            angle = Geometry.ComputeEllipseAngle(Markers[1].CenterPosition, Markers[2].CenterPosition);

            x = 0; y = b;

            DrawPixel(e, Pen);
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

                DrawPixel(e, Pen);
                x = -x;


                DrawPixel(e, Pen);
                x = -x;
            }

            x = a;
            y = 0;

            DrawPixel(e, Pen);
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

                DrawPixel(e, Pen);
                y = -y;

                DrawPixel(e, Pen);
                y = -y;
            }
        }

        Point _rotatedPoint;
        private void DrawPixel(Graphics e, Pen pen)
        {
            //angle = -angle;

            _rotatedPoint = Geometry.RotatePointAroundOrigin(angle, x, y);
            e.DrawRectangle(pen, xc - _rotatedPoint.X, yc - _rotatedPoint.Y, 1, 1);
            e.DrawRectangle(pen, xc + _rotatedPoint.X, yc + _rotatedPoint.Y, 1, 1);
        }
    }
}
