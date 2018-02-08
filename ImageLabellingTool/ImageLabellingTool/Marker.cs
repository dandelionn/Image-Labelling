using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageLabellingTool
{
    public partial class Marker : UserControl
    {
        public Point CenterPosition { get; set;}

        public Marker()
        {
            InitializeComponent();
            SetCenterPosition();
        }

        private void SetCenterPosition()
        {
            CenterPosition = new Point(this.Location.X + this.Size.Width / 2, this.Location.Y + this.Size.Height / 2);
        }

        private void Marker_LocationChanged(object sender, EventArgs e)
        {
            SetCenterPosition();
        }

        private void Marker_SizeChanged(object sender, EventArgs e)
        {
            SetCenterPosition();
        }
    }
}
