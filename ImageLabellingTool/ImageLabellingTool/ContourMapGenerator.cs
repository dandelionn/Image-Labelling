
using System;
using System.Collections.Generic;
using System.Drawing;


namespace ImageLabellingTool
{
    public class ContourMapGenerator
    {
        private int[,] _contourMask;

        public ContourMapGenerator()
        {

        }

        int _contourIndex;
        public Bitmap GenerateContourImage(Bitmap bitmap, List<Contour> contours)
        {
            _contourIndex = 0;
            _contourMask = new int[bitmap.Width, bitmap.Height];

            foreach (Contour contour in contours)
            {
                AddContourToMask(_contourMask, contour);

                _contourIndex++;
            }

            FillContourMask(_contourMask, bitmap.Width, bitmap.Height);
            return ExtractSectionsFromImage(bitmap, _contourMask);
        }



        struct Element { public int up, down, left, right; };
        Element[,] _neighbour;

        private void FillContourMask(int[,] contourMask, int rows, int columns)
        {
            _neighbour = new Element[rows, columns];
            AssignLeftNeighbours(contourMask, rows, columns);
            AssignRightNeighbours(contourMask, rows, columns);
            AssignUpNeighbours(contourMask, rows, columns);
            AssignDownNeighbours(contourMask, rows, columns);

            SeparateSections(contourMask, rows, columns);
            AdjustSections(contourMask, rows, columns);
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

        private void AdjustSections(int[,] contourMask, int rows, int columns)
        {
            Console.WriteLine("Start Separate");
            List<int> sectionNumbers = GetSectionsIdentifiers(contourMask, rows, columns);
            List<Element> neighbourSamples = new List<Element>();
            foreach (int id in sectionNumbers)
            {
                neighbourSamples.Add(GetNeighbourSampleForIdentifier(contourMask, rows, columns, id));
            }

            ModifySections(contourMask, rows, columns, sectionNumbers, neighbourSamples);
            Console.WriteLine("End Separate");
        }

        private void ModifySections(int[,] contourMask, int rows, int columns, List<int> sectionNumbers, List<Element> neighbourSamples)
        {
            bool isValid;
            for (int i = 0; i < sectionNumbers.Count; i++)
            {
                isValid = CheckSection(contourMask, rows, columns, sectionNumbers[i], neighbourSamples[i]);
                if (isValid)
                {
                    ModifySection(contourMask, rows, columns, sectionNumbers[i], neighbourSamples[i].left);
                }
                else
                {
                    ModifySection(contourMask, rows, columns, sectionNumbers[i], 0);
                }
            }
        }

        private bool CheckSection(int[,] contourMask, int rows, int columns, int id, Element neighbourSample)
        {
            int i, j;

            for (i = 0; i < rows; i++)
            {
                for (j = 0; j < columns; j++)
                {
                    if (contourMask[i, j] == id)
                    {
                        if (!TestNeighbours(_neighbour[i, j], neighbourSample))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void ModifySection(int[,] contourMask, int rows, int columns, int id, int actualId)
        {
            int i, j;
            for (i = 0; i < rows; i++)
            {
                for (j = 0; j < columns; j++)
                {
                    if (contourMask[i, j] == id)
                    {
                        contourMask[i, j] = actualId;
                    }
                }
            }
        }

        private bool TestNeighbours(Element A, Element B)
        {
            return A.left == B.left && A.right == B.right && A.up == B.up && A.down == B.down;
        }

        private Element GetNeighbourSampleForIdentifier(int[,] contourMask, int rows, int columns, int id)
        {
            int i, j;
            for (i = 0; i < rows; i++)
            {
                for (j = 0; j < columns; j++)
                {
                    if(contourMask[i, j] == id)
                    {
                        return _neighbour[i, j];
                    }
                }
            }

            return new Element();
        }

        private List<int> GetSectionsIdentifiers(int[,] contourMask, int rows, int columns)
        {
            int i, j;
            List<int> sectionNumbers = new List<int>();

            for (i = 0; i < rows; i++)
            {
                for (j = 0; j < columns; j++)
                {
                    if (contourMask[i, j] < 0)
                    {
                        if (!sectionNumbers.Contains(contourMask[i, j]))
                        {
                            sectionNumbers.Add(contourMask[i, j]);
                        }
                    }
                }
            }

            return sectionNumbers;
        }

        private void SeparateSections(int[,] contourMask, int rows, int columns)
        {
            Console.WriteLine("Start Separate");
            int i, j, value, min, max;

            int sectionIndex = -1;
            int x, y;
            for (i = 1; i < rows - 1; i++)
            {
                value = 0;
                for (j = 1; j < columns - 1; j++)
                {
                   // Console.WriteLine("i:" + i + "j:" + j);
                    if (contourMask[i, j] == 0)
                    {
                        if (contourMask[i - 1, j] < 0 && contourMask[i, j - 1] < 0)
                        {
                            min = Math.Min(contourMask[i - 1, j], contourMask[i, j - 1]);
                            max = Math.Min(contourMask[i - 1, j], contourMask[i, j - 1]);

                            contourMask[i, j] = max;
                            for (x = 1; x < rows - 1; x++)
                            {
                                for (y = 1; y < columns - 1; y++)
                                {
                                    if (contourMask[x, y] == min)
                                    {
                                        contourMask[x, y] = max;
                                    }
                                }

                                Console.WriteLine("x:" + x + "y:" + y);
                            }
                            
                           
                        }
                        else
                        {
                            if (contourMask[i - 1, j] <= 0)
                            {
                                contourMask[i, j] = contourMask[i - 1, j];
                            }
                            else if (contourMask[i, j - 1] <= 0)
                            {
                                contourMask[i, j] = contourMask[i, j - 1];
                            }
                            else if (contourMask[i - 1, j] > 0 && contourMask[i, j - 1] > 0)
                            {
                                contourMask[i, j] = sectionIndex;
                                sectionIndex--;
                            }
                        }
                    }
                }
            }
           // Console.WriteLine("End Separate");
        }

        private void AssignLeftNeighbours(int[,] contourMask, int rows, int columns)
        {
            int i, j, value;

            //left neighbours
            for (i = 0; i < rows; i++)
            {
                value = 0;
                for (j = 0; j < columns; j++)
                {
                    if (contourMask[i, j] != 0)
                    {
                        value = contourMask[i, j];
                    }
                    else
                    {
                        _neighbour[i,j].left = value;
                    }
                }
            }
        }

        private void AssignRightNeighbours(int[,] contourMask, int rows, int columns)
        {
            int i, j, value;

            //right neighbours
            for (i = 0; i < rows; i++)
            {
                value = 0;
                for (j = columns - 1; j >= 0; j--)
                {
                    if (contourMask[i, j] != 0)
                    {
                        value = contourMask[i, j];
                    }
                    else
                    {
                        _neighbour[i, j].right = value;
                    }
                }
            }
        }

        private void AssignUpNeighbours(int[,] contourMask, int rows, int columns)
        {
            int i, j, value;

            //up neighbours
            for (i = 0; i < columns; i++)
            {
                value = 0;
                for (j = 0; j < rows; j++)
                {
                    if (contourMask[j, i] != 0)
                    {
                        value = contourMask[j, i];
                    }
                    else
                    {
                        _neighbour[j, i].up = value;
                    }
                }
            }
        }

        private void AssignDownNeighbours(int[,] contourMask, int rows, int columns)
        {
            int i, j, value;

            //down neighbours
            for (i = 0; i < columns; i++)
            {
                value = 0;
                for (j = rows - 1; j >= 0; j--)
                {
                    if (contourMask[j, i] != 0)
                    {
                        value = contourMask[j, i];
                    }
                    else
                    {
                        _neighbour[j, i].down = value;
                    }
                }
            }
        }

        private void AddContourToMask(int[,] contourMask, Contour contour)
        {
            for (int i = 0; i < contour.Markers.Count - 1; i++)
            {
                DrawLinePointsWithSlope(contourMask, contour.Markers[i].CenterPosition, contour.Markers[i + 1].CenterPosition);
            }

            DrawLinePointsWithSlope(contourMask, contour.Markers[0].CenterPosition, contour.Markers[contour.Markers.Count - 1].CenterPosition);
        }

        private void DrawLinePointsWithSlope(int[,] contourMask, Point A, Point B)
        {
            int x, y;
            double dx = A.X - B.X;
            double dy = A.Y - B.Y;

            if (dx == 0)
            {
                if (A.Y <= B.Y)
                {
                    for (y = A.Y; y <= B.Y; y++)
                    {
                        contourMask[A.X, y] = _contourIndex;
                    }
                }
                else
                {
                    for (y = B.Y; y <= A.Y; y++)
                    {
                        contourMask[A.X, y] = _contourIndex;
                    }
                }
            }
            else
            {
                if (A.X <= B.X)
                {
                    for (x = A.X; x <= B.X; x++)
                    {
                        y = (int)(A.Y + dy * (x - (double)A.X) / dx);

                        contourMask[x, y] = _contourIndex;
                    }
                }
                else
                {
                    for (x = B.X; x <= A.X; x++)
                    {
                        y = (int)(A.Y + dy * (x - (double)A.X) / dx);

                        contourMask[x, y] = _contourIndex;
                    }
                }
            }
        }
    }
}
