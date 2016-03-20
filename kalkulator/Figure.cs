using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    abstract class Figure
    {
        //Поля

            public abstract List<Point> FillPoints { get; }
            public int r = 20;
            Color c = Color.LimeGreen;
            public Point location = new Point();
            public Point RightPoint
                    {
                        get
                        {
                            Point res = location;
                            foreach (Point p in FillPoints)
                            {
                                if (res.X < p.X)
                                {
                                    res = p;
                                }
                            }
                            return res;
                        }
                    }

            public int state { get; set; }


        //Конструктор

        //Методы 

        public void DrowFigure(Graphics gr)
        {
            Pen p = new Pen(Color.Black,2);
            SolidBrush b = new SolidBrush(c);
            foreach (Point point in FillPoints)
            {
                 gr.FillRectangle(b, point.X, point.Y, r, r);
                 gr.DrawRectangle(p,point.X,point.Y,r,r);
            }
        }

        public void step()
        {
            location = new Point(location.X,location.Y + r);
        }

        public Point SLT
        {
            get
            {
                return Down_Point;
            }
        }

        

        public Point Down_Point
        {
            get
            {
                Point p1 = new Point();
                        p1 = location;
               foreach (Point p in FillPoints)
                {
                    if (p1.Y < p.Y)
                        p1 = p;
                }
               return p1;
            }
        }

        public virtual void ratate()
        {

        }

    }
}
