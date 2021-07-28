using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Fuzzy
{
    class RectangleSet : IFuzzySet
    {
        private double x_min, x_max, y_min, y_max;
        public RectangleSet(double x_min, double x_max, double y_min, double y_max)
        {
            this.x_min = x_min;
            this.x_max = x_max;
            this.y_min = y_min;
            this.y_max = y_max;
        }

        public double GetValueInPoint(double p)
        {
            if(p<x_min || p > x_max)
            {
                return y_min;
            }
            return y_max;
        }
    }
}
