using System;
using System.Drawing;

namespace Paint_Graphics
{
    internal abstract class Shape
    {
        private readonly Pen pen;
        public Pen Pen { get => pen; }
        public Shape(Pen pen)
        {
            this.pen = (Pen)pen.Clone();
        }

        abstract public void Draw(Graphics graphics);
    }
}