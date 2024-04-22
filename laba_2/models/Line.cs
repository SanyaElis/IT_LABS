namespace laba_2.models
{
    public class Line : Figure
    {
        private const string DEFAULT_NAME = "Линия";
        private Coordinate _p1;
        private Coordinate _p2;
        public Line(Coordinate p1, Coordinate p2)
        {
            _p1 = p1;
            _p2 = p2;
            center = new Coordinate((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
            name = DEFAULT_NAME;
        }



        protected override Coordinate[] GetBounds()
        {
            Coordinate[] bounds = new Coordinate[4];
            bounds[0] = new Coordinate(double.NegativeInfinity, double.NegativeInfinity);
            bounds[1] = new Coordinate(double.NegativeInfinity, double.PositiveInfinity);
            bounds[2] = new Coordinate(double.PositiveInfinity, double.PositiveInfinity);
            bounds[3] = new Coordinate(double.PositiveInfinity, double.NegativeInfinity);
            return bounds;
        }

        protected override double CountArea()
        {
            return 0;
        }

        protected override string GenerateDescription()
        {
            return $"Линия заданная двумя точками {_p1} и {_p2}";
        }
    }
}
