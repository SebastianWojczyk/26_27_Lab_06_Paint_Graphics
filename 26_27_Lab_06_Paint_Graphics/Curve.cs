using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Paint_Graphics
{
    internal class Curve : Shape
    {
        private readonly List<Point> points;
        public int Count => points.Count;
        public Curve(Pen pen) : base(pen)
        {
            points = new List<Point>();
        }
        public void AddPoint(Point point)
        {
            points.Add(point);
        }

        public override void Draw(Graphics graphics)
        {
            for (int i = 0; i < Count - 1; i++)
            {
                graphics.DrawLine(Pen,
                                  this[i],
                                  this[i + 1]);
            }
        }

        public Point this[int index]
        {
            get
            {
                return points[index];
            }
        }
    }
}
