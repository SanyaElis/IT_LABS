using System;
using System.Collections.Generic;
using System.Text;

namespace laba_2.models
{
    public class Polygon : Figure
    {
        protected List<Coordinate> _vertices;
        private const string DEFAULT_NAME = "Многоугольник";
        public Polygon(List<Coordinate> vertices)
        {
            _vertices = vertices;
            name = DEFAULT_NAME;
            center = FindCenter();
        }
        protected override double CountArea()
        {
            double area = 0;
            for (int i = 0; i < _vertices.Count; i++)
            {
                int j = (i + 1) % _vertices.Count;
                area += _vertices[i].X * _vertices[j].Y - _vertices[j].X * _vertices[i].Y;
            }
            area = Math.Abs(area) / 2;
            return area;
        }

        protected override string GenerateDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{_vertices.Count} угольник с центром в точке {center}\nИ координатами вершин:\n");
            foreach (Coordinate coord in _vertices)
            {
                sb.Append(coord.ToString()).Append("\n");
            }

            return sb.ToString().Trim(); ;
        }
        private Coordinate FindCenter()
        {
            double centerX = 0;
            double centerY = 0;
            foreach (Coordinate point in _vertices)
            {
                centerX += point.X;
                centerY += point.Y;
            }
            centerX /= _vertices.Count;
            centerY /= _vertices.Count;
            return new Coordinate(centerX, centerY);
        }
        protected override Coordinate[] GetBounds()
        {
            Coordinate[] bounds = new Coordinate[4];
            double maxX = Math.Abs(_vertices[0].X);
            double maxY = Math.Abs(_vertices[0].Y);
            foreach (Coordinate point in _vertices)
            {
                if (Math.Abs(point.X) > maxX)
                    maxX = point.X;
                if (Math.Abs(point.Y) > maxY)
                    maxY = point.Y;
            }
            bounds[0] = new Coordinate(-maxX, -maxY);
            bounds[1] = new Coordinate(-maxX, maxY);
            bounds[2] = new Coordinate(maxX, maxY);
            bounds[3] = new Coordinate(maxX, -maxY);
            return bounds;
        }
    }
}
