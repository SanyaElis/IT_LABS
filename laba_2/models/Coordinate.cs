using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2.models
{
    public class Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double Distance(Coordinate other)
        {
            return Math.Sqrt((X-other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y));
        }
    }
}
