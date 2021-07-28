using Assets.Fuzzy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Variables
{
    class FAM 
    {
        private IFuzzySet[,] AMatrix;
        private double[,] weights;
        private IFuzzySet[] result;
        public FAM(IFuzzySet[] result)
        {
            this.result = result;
        }

        public double GetValueInPoint(double p)
        {
            List<double> values = new List<double>();
            for(int i = 0; i < AMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < AMatrix.GetLength(1); j++)
                {
                    values.Add(weights[i, j] < AMatrix[i, j].GetValueInPoint(p) ? weights[i, j] : AMatrix[i, j].GetValueInPoint(p));
                }
            }
            return values.Max();
        }

        public void SetMatrix(double[] phi, double[] x, bool first)
        {
            if (first)
            {
                weights = new double[phi.Length, x.Length];
                AMatrix = new IFuzzySet[phi.Length, x.Length];
            }
            for (int i = 0; i < phi.Length; i++)
            {
                for (int j = 0; j < x.Length; j++)
                {
                    weights[i, j] = phi[i] < x[j] ? phi[i] : x[j];
                }
            }
        }

        private delegate double function(double x);
        private double Int(function f, double a, double b, double h)
        {
            double ret = 0;
            while (a < b)
            {
                ret += h * f(a);
                a += h;
            }
            return ret;
        }

        private double Ch(double p)
        {
            double ret = GetValueInPoint(p);
            return ret * p;
        }

        public double GetCentroid()
        {
            double ch = Int(Ch, -30, 30, 0.1);
            double zn = Int(GetValueInPoint, -30, 30, 0.1);
            return ch / zn;
        }

        Random rnd = new Random();

        public void RandomAM(double probability)
        {
            for (int i = 0; i < AMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < AMatrix.GetLength(1); j++)
                {
                    if (rnd.NextDouble() <= probability)
                    {
                        AMatrix[i, j] = result[rnd.Next(0, result.Length)];
                    }
                }
            }
        }
    }
}
