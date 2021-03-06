﻿using System;
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
                switch (state)
                {
                    case 0:
                        {
                            result.Add(location);
                            result.Add(new Point(location.X, location.Y + 3 * r));
                            result.Add(new Point(location.X, location.Y + r));
                            result.Add(new Point(location.X, location.Y + 2 * r));
                        }
                        break;

                    case 1:
                        {
                            result.Add(location);
                            result.Add(new Point(location.X + r, location.Y));
                            result.Add(new Point(location.X + 2 * r, location.Y));
                            result.Add(new Point(location.X + 3 * r, location.Y));
                        }
                        break;

                }
                return result;
            }
            
        }

        public override void ratate()
        {
            state = (state + 1) % 2;
        }

    }
}
