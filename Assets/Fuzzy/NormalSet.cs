using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Fuzzy
{
    class NormalSet : IFuzzySet
    {
        private double mu, sigma, y_max;
        public NormalSet(double mu, double sigma, double y_max)
        {
            this.mu = mu;
            this.sigma = sigma;
            this.y_max = y_max;
        }
        public double GetValueInPoint(double p)
        {
            double e = Math.Exp(-(p - mu) * (p - mu) / (2 * sigma * sigma));
            double f = e / (sigma * Math.Sqrt(2 * Math.PI));
            return f * 2.5 * sigma * y_max;
        }
    }
}
