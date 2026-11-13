using Paint_Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _26_27_Lab_06_Paint_Graphics
{
    public partial class Form1 : Form
    {
        List<Shape> shapes = new List<Shape>();
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

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = e.Location.ToString();

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