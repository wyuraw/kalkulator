using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int Skor = 0;
        int r = 20;
        int[,] tetr = new int[18,24];
        Figure figure;
        List<Point> Tochki = new List<Point>();
        Color c = Color.LimeGreen;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (canmove())
            {
                figure.step();
                pictureBox1.Invalidate();
            }
            else
            {
                End();
                foreach (Point p in figure.FillPoints)
                {
                    tetr[p.X / r, p.Y / r] = 1;
                    Tochki.Add(p);
                }
                CheckPoint();
                Shape_Generate();
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            figure.DrowFigure(e.Graphics);
            DrowPoints(e.Graphics);
        }

        public void DrowPoints(Graphics gr)
        {
            Pen p = new Pen(Color.Black, 2);
            SolidBrush b = new SolidBrush(c);
            foreach (Point point in Tochki)
            {
                gr.FillRectangle(b, point.X, point.Y, r, r);
                gr.DrawRectangle(p,point.X,point.Y,r,r);
            }
            for (int i = 0; i < tetr.GetLength(0); i++)
            {
                for (int j = 0; j < tetr.GetLength(1); j++)
                {
                    if (tetr[i, j] != 0)
                    {
                        SolidBrush Brush = new SolidBrush(Color.Black);
                        gr.FillEllipse(Brush, new Rectangle(new Point(i * 20, j * 20), new Size(5, 5)));
                    }
                }
            }
        }

        public bool canmove()
        {
            bool can = figure.SLT.Y + figure.r < pictureBox1.Height;
            foreach (Point point in Tochki)
            {
                foreach (Point point1 in figure.FillPoints)
                {
                    if (point.Equals(new Point(point1.X, point1.Y + figure.r)))
                        return false;
                }
            }
                return can;
        }

        private void End()
        {
            if (figure.location.Y < 1)
            {
                pictureBox1.Invalidate();
                timer1.Enabled = false;
                MessageBox.Show("Вы проиграли!");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    {
                        if (canright())
                       figure.location = new Point(figure.location.X + figure.r,figure.location.Y);
                    }
                    break;
                case Keys.A:
                    {
                        if (canleft())
                        figure.location = new Point(figure.location.X - figure.r, figure.location.Y);
                    }
                    break;
                case Keys.S:
                    {
                        while (canmove())
                        {
                            figure.step();
                            pictureBox1.Invalidate();
                        }
                    }
                    break;
            } 
                    pictureBox1.Invalidate();
        }

        public bool canleft()
        {
            bool can = figure.SLT.X - figure.r >= 0;
            foreach (Point point in Tochki)
            {
                foreach (Point point1 in figure.FillPoints)
                {
                    if (point.Equals(new Point(point1.X - figure.r, point1.Y)))
                        return false;
                }
            }
                return can;
        }

        public bool canright()
        {
            bool can = figure.RightPoint.X + figure.r < pictureBox1.Width;
            foreach (Point point in Tochki)
            {
                foreach (Point point1 in figure.FillPoints)
                {
                    if (point.Equals(new Point(point1.X + figure.r, point1.Y)))
                        return false;
                }
            }
            return can;
        }

        private void CheckPoint()
        {
            for (int i = 0; i < tetr.GetLength(1); i++)
            {
                bool isDel = true;
                for (int j = 0; j < tetr.GetLength(0); j++)
                {
                    if (tetr[j, i] == 0)
                    {
                        isDel = false;
                        break;
                    }
                }
                if (isDel)
                {
                    Skor += 100;
                    for (int j = 0; j < tetr.GetLength(0); j++)
                    {
                        tetr[j, i] = 0;
                        for (int k = i; k > 0; k--)
                        {
                            tetr[j, k] = tetr[j, k - 1];
                        }
                    }
                    Tochki.Clear();
                    for (int i1 = 0; i1 < tetr.GetLength(0); i1++)
                    {
                        for (int j1 = 0; j1 < tetr.GetLength(1); j1++)
                        {
                            if (tetr[i1,j1] != 0)
                            {
                                Point pt = new Point(i1 * 20, j1 * 20);
                                Tochki.Add(pt);
                            }
                        }
                    }
                }
            }
            label1.Text = Skor.ToString();
        }

        public void Shape_Generate()
        {
            Random r = new Random();
            switch(r.Next(0,3))
            {
                case 0:
                    figure = new Squire();
                    break;
                case 1:
                    figure = new bykva_r();
                    break;
                case 2:
                    figure = new Line();
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Shape_Generate();
        }

   }
}
