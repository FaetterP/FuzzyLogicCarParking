using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Fuzzy
{
    class TrapezoidSet : IFuzzySet
    {
        private double x_1, x_2, x_3, x_4, y_min, y_max;
        public TrapezoidSet(double x_1, double x_2, double x_3, double x_4, double y_min, double y_max)
        {
            this.x_1 = x_1;
            this.x_2 = x_2;
            this.x_3 = x_3;
            this.x_4 = x_4;
            this.y_min = y_min;
            this.y_max = y_max;
        }

        public double GetValueInPoint(double p)
        {
            if (p < x_1 || p > x_4)
            {
                return y_min;
            }
            else if (p < x_2)
            {
                double slope = (y_max - y_min) / (x_2 - x_1);
                double intercept = (y_min * x_2 - y_max * x_1) / (x_2 - x_1);
                return slope * p + intercept;
            }
            else if (p < x_3)
            {
                return y_max;
            }
            else
            {
                double slope = (y_min - y_max) / (x_4 - x_3);
                double intercept = (y_max * x_4 - y_min * x_3) / (x_4 - x_3);
                return slope * p + intercept;
            }
        }
    }
}
