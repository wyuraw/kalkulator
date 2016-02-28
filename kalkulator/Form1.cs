﻿using System; 
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
        int r = 20;
        
        Class1 figure = new Class1();
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
                    Tochki.Add(p);
                }
                figure = new Class1();
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
                 Pen p = new Pen(Color.Black,2);
                 SolidBrush b = new SolidBrush(c);
                 foreach (Point point in Tochki)
             {
                 gr.FillRectangle(b, point.X, point.Y, r, r);
                 gr.DrawRectangle(p,point.X,point.Y,r,r);
             }
        }

        public bool canmove()
        {
            bool can = figure.SLT.Y + figure.r < pictureBox1.Height;
            foreach (Point point in Tochki)
            {
                foreach (Point point1 in figure.FillPoints)
                {
                    if (point.Equals(new Point(point.X, point1.Y + figure.r)))
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
            bool can = figure.RightPoint.X + figure.r <= pictureBox1.Width;
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

        

    }
}