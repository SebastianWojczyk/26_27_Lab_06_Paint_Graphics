using Paint_Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_27_Lab_06_Paint_Graphics
{
    internal class Ellipse : Shape
    {
        private readonly Point pointLeftTop;
        private readonly Size size;

        public Point PointLeftTop => pointLeftTop;
        public Size Size => size;

        public Ellipse(Pen pen, Point pointLeftTop, Size size) : base(pen)
        {
            this.pointLeftTop = pointLeftTop;
            this.size = size;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pen,
                                   pointLeftTop.X,
                                   pointLeftTop.Y,
                                   size.Width,
                                   size.Height
                                  );
        }
    }
}
