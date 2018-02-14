
using System;
using System.Collections.Generic;
using System.Drawing;


namespace ImageLabellingTool
{
    public class ContourMapGenerator
    {
        private int[,] _contourMask;
        int _contourIndex;

        public ContourMapGenerator()
        {

        }

        public Bitmap GenerateContourImage(Bitmap bitmap, List<Contour> contours)
        {
            _contourIndex = 1;
            _contourMask = new int[bitmap.Width, bitmap.Height];

            foreach (Contour contour in contours)
            {
                AddContourToMask(_contourMask, contour);

                FillContour(_contourMask, contour, bitmap.Width, bitmap.Height);

                _contourIndex++;
            }

            return ExtractSectionsFromImage(bitmap, _contourMask);
        }

        private void FillContour(int[,] mask, Contour contour, int width, int height)
        {
            Point insidePoint = FindInsidePoint(contour);
            Mark(mask, insidePoint, mask[contour.Markers[0].CenterPosition.X, contour.Markers[0].CenterPosition.Y], width, height);
        }

        private Point FindInsidePoint(Contour contour)
        {
            Point gravityCenter = new Point();

            int valid;
            for(int i=0; i < contour.Markers.Count - 2; i++)
            {
                valid = 0;

                gravityCenter.X = (contour.Markers[i].CenterPosition.X + contour.Markers[i + 1].CenterPosition.X + contour.Markers[i + 2].CenterPosition.X) / 3;
                gravityCenter.Y = (contour.Markers[i].CenterPosition.Y + contour.Markers[i + 1].CenterPosition.Y + contour.Markers[i + 2].CenterPosition.Y) / 3;

                for (int j = 0; j < contour.Markers.Count - 1; j++)
                {
                    valid += IsInsidePoint(gravityCenter, contour.Markers[i].CenterPosition, contour.Markers[i + 1].CenterPosition);
                }

                valid += IsInsidePoint(gravityCenter, contour.Markers[0].CenterPosition, contour.Markers[contour.Markers.Count - 1].CenterPosition);

                if(valid  % 2 == 0)
                {
                    return gravityCenter;
                }
            }


            return gravityCenter;
        }

        public int IsInsidePoint(Point point, Point A, Point B)
        {
            //it is enough to test only the segments situated on the right side of the point
            if(A.X < point.X && B.X < point.X) //segment situated on the left side 
            {
                return 0;
            }

            bool side1;
            bool side2;

            side1 = A.Y < point.Y;
            side2 = B.Y > point.Y;

            if (side1 == side2)
            {
                return 1;

            }
            else
            {
                side1 = A.Y == point.Y;
                side2 = B.Y == point.Y;
                if ((side1 == side2))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        void Mark(int[,] mask, Point startPoint, int id, int  width, int height)
        {
            Stack<Point> stack = new Stack<Point>();

            stack.Push(startPoint);

            Point currentPoint;
            int x, y;
            while(stack.Count > 0)
            {
                currentPoint = stack.Pop();
                x = currentPoint.X;
                y = currentPoint.Y;
                mask[x, y] = id;

                if (x > 0 && x < width - 1 && y > 0 && y < height - 1)
                {
                    if (mask[x - 1, y] == 0)
                    {
                        stack.Push(new Point(x - 1, y));
                    }
                    if (mask[x, y - 1] == 0)
                    {
                        stack.Push(new Point(x, y - 1));
                    }
                    if (mask[x + 1, y] == 0)
                    {
                        stack.Push(new Point(x + 1, y));
                    }
                    if (mask[x, y + 1] == 0)
                    {
                        stack.Push(new Point(x, y + 1));
                    }
                }
            }
        }

        private Bitmap ExtractSectionsFromImage(Bitmap bitmap, int[,] contourMask)
        {
            Bitmap contourBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            int i, j;

            for (i = 0; i < bitmap.Width; i++)
            {
                for (j = 0; j < bitmap.Height; j++)
                {
                    if (contourMask[i, j] > 0)
                    {
                        contourBitmap.SetPixel(i, j, bitmap.GetPixel(i, j));
                    }
                    else
                    {
                        contourBitmap.SetPixel(i, j, Color.Black);
                    }
                }
            }

            return contourBitmap;
        }

        private void AddContourToMask(int[,] contourMask, Contour contour)
        {
            for (int i = 0; i < contour.Markers.Count - 1; i++)
            {
                DrawLines(contourMask, contour.Markers[i].CenterPosition, contour.Markers[i + 1].CenterPosition);
            }

            DrawLines(contourMask, contour.Markers[0].CenterPosition, contour.Markers[contour.Markers.Count - 1].CenterPosition);
        }

        private void DrawLines(int[,] contourMask, Point A, Point B)
        {
            IEnumerable<Point> enumerator = EnumerateLineNoDiagonalSteps(A.X, A.Y, B.X, B.Y);

            foreach(Point point in enumerator)
            {
                contourMask[point.X, point.Y] = _contourIndex;
            }
        }

        public static IEnumerable<Point> EnumerateLineNoDiagonalSteps(int x0, int y0, int x1, int y1)
        {
            int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
            int dy = -Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
            int err = dx + dy, e2;

            while (true)
            {
                yield return new Point(x0, y0);

                if (x0 == x1 && y0 == y1) break;

                e2 = 2 * err;

                // EITHER horizontal OR vertical step (but not both!)
                if (e2 > dy)
                {
                    err += dy;
                    x0 += sx;
                }
                else if (e2 < dx)
                { // <--- this "else" makes the difference
                    err += dx;
                    y0 += sy;
                }
            }
        }
    }
}
