using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public abstract class ContourOperator
    {
        public PictureBox PictureBox { get; set; }
        protected ContourMap _contourMap;

        protected Point _rectStartPoint;
        protected Rectangle _selectedRect;

        public abstract void RemoveResources();

        public ContourOperator()
        {
            _contourMap = ContourMap.GetInstance(PictureBox);
        }
    }
}
