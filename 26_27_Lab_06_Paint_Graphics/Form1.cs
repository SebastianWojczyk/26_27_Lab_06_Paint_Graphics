using Paint_Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _26_27_Lab_06_Paint_Graphics
{
    public partial class Form1 : Form
    {
        private Point pointStart;
        private List<Shape> shapes = new List<Shape>();
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += Form1_Paint;

            //default values for Pen
            buttonColor.BackColor = Color.Black;
            numericUpDownWidth.Value = 5;

            if (listBoxShapes.Items.Count > 0)
            {
                listBoxShapes.SelectedIndex = 0;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.White);

            //e.Graphics.DrawString("Example of text", new Font("Arial", 16), Brushes.Black, 100, 100);

            foreach (Shape shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }



        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listBoxShapes.Text == "Krzywa")
                {
                    Pen myPen = new Pen(buttonColor.BackColor, (int)numericUpDownWidth.Value);
                    myPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    myPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                    shapes.Add(new Curve(myPen));
                    (shapes.Last() as Curve).AddPoint(e.Location);
                }
                else if (listBoxShapes.Text == "Prostokąt" ||
                         listBoxShapes.Text == "Elipsa" ||
                         listBoxShapes.Text == "Prosta")
                {
                    pointStart = e.Location;
                }
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = $"Współrzędne: {e.Location} Przycisk: {e.Button}";

            if (e.Button == MouseButtons.Left)
            {
                if (listBoxShapes.Text == "Krzywa")
                {
                    if (shapes.Last() is Curve)
                    {
                        Curve curve = (Curve)shapes.Last();
                        curve.AddPoint(e.Location);
                        Invalidate();
                    }
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listBoxShapes.Text == "Prostokąt" ||
                    listBoxShapes.Text == "Elipsa")
                {
                    Pen myPen = new Pen(buttonColor.BackColor, (int)numericUpDownWidth.Value);
                    myPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    myPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                    Point pointLeftTop = new Point(Math.Min(pointStart.X, e.Location.X),
                                                   Math.Min(pointStart.Y, e.Location.Y));
                    Size size = new Size(Math.Abs(pointStart.X - e.Location.X),
                                         Math.Abs(pointStart.Y - e.Location.Y));
                    if (listBoxShapes.Text == "Prostokąt")
                    {
                        shapes.Add(new Rectangle(myPen, pointLeftTop, size));
                    }
                    else if (listBoxShapes.Text == "Elipsa")
                    {
                        shapes.Add(new Ellipse(myPen, pointLeftTop, size));
                    }
                    Invalidate();
                }
                else if (listBoxShapes.Text == "Prosta")
                {
                    Pen myPen = new Pen(buttonColor.BackColor, (int)numericUpDownWidth.Value);
                    myPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    myPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                    shapes.Add(new Line(myPen, pointStart, e.Location));
                    Invalidate();
                }
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = buttonColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                buttonColor.BackColor = cd.Color;
            }
        }
    }
}