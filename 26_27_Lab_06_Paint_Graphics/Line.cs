using Paint_Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_27_Lab_06_Paint_Graphics
{
    internal class Line : Shape
    {
        private readonly Point pointStart;
        private readonly Point pointStop;

        public Point PointStart => pointStart;
        public Point PointStop => pointStop;


        public Line(Pen pen, Point pointStart, Point pointStop) : base(pen)
        {
            this.pointStart = pointStart;
            this.pointStop = pointStop;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(Pen,
                              pointStart.X,
                              pointStart.Y,
                              pointStop.X,
                              pointStop.Y
                             );
        }
    }
}
