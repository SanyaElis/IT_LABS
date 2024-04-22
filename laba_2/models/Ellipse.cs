using System;

namespace laba_2.models
{
    internal class Ellipse : Figure
    {
        private const string DEFAULT_NAME = "Эллипс";
        private double _r1;
        private double _r2;
        public Ellipse(Coordinate center, double r1, double r2)
        {
            this.center = center;
            _r1 = r1;
            _r2 = r2;
            name = DEFAULT_NAME;
        }

        protected override Coordinate[] GetBounds()
        {
            Coordinate[] bounds = new Coordinate[4];
            bounds[0] = new Coordinate(center.X - _r1, center.Y - _r2);
            bounds[1] = new Coordinate(center.X - _r1, center.Y + _r2);
            bounds[2] = new Coordinate(center.X + _r1, center.Y + _r2);
            bounds[3] = new Coordinate(center.X + _r1, center.Y - _r2);
            return bounds;
        }

        protected override double CountArea()
        {
            return Math.Round(Math.PI * _r1 * _r2, 3);
        }

        protected override string GenerateDescription()
        {
            return $"Эллипс с координатой центра {center}\nС радиусами r1 = {_r1} r2 = {_r2}";
        }
    }
}
