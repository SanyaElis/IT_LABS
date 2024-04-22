namespace laba_2.models
{
    public class Point : Figure
    {
        private const string DEFAULT_NAME = "Точка";
        public Point(Coordinate center)
        {
            this.center = center;
            name = DEFAULT_NAME;
        }

        protected override Coordinate[] GetBounds()
        {
            Coordinate[] bounds = new Coordinate[4];
            bounds[0] = new Coordinate(center.X, center.Y);
            bounds[1] = new Coordinate(center.X, center.Y);
            bounds[2] = new Coordinate(center.X, center.Y);
            bounds[3] = new Coordinate(center.X, center.Y);
            return bounds;
        }



        protected override double CountArea()
        {
            return 0;
        }

        protected override string GenerateDescription()
        {
            return $"Точка {center}";
        }
    }
}
