﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2.models
{
    public abstract class Figure
    {
        protected Coordinate center;
        public abstract double Area();

        public Coordinate GetCenter()
        {
            return center;
        }

        public abstract Coordinate[] GetBounds();
    }
}
