using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Line: Figure
    {
        public override List<Point> FillPoints
        {
            get
            {
                List<Point> result = new List<Point>();
                result.Add(location);
                result.Add(new Point(location.X, location.Y + 3 * r));
                result.Add(new Point(location.X, location.Y + r));
                result.Add(new Point(location.X, location.Y + 2 * r));
                return result;
            }
        }

        public override Point SLT
        {
            get
            {
                Point result = new Point(location.X, location.Y + 3 * r);
                return result;
            }
        }
    }
}
