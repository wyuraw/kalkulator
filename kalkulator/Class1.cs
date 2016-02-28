using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Class1
    {
        public int r = 20;
        Color c = Color.LimeGreen;
        public Point location = new Point(); 

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

        public List<Point> FillPoints
        {
            get
            {
                List<Point> result = new List<Point>();
                result.Add(location);
                result.Add(new Point(location.X , location.Y + r));
                result.Add(new Point(location.X +  r, location.Y + r));
                result.Add(new Point(location.X +  r, location.Y));
                return result;
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
                Point result = new Point(location.X,location.Y + r);
                return result;
            }
        }

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

    }
}
