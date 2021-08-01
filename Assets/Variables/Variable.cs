using Assets.Fuzzy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Variables
{
    class Variable
    {
        private IFuzzySet[] sets;

        public Variable(IFuzzySet[] sets)
        {
            this.sets = sets;
        }

        public double[] GetArrWeightsInPoint(double p)
        {
            double[] ret = new double[sets.Length];
            for(int i = 0; i < ret.Length; i++)
            {
                ret[i] = sets[i].GetValueInPoint(p);
            }
            return ret;
        }

        public int GetLength()
        {
            return sets.Length;
        }
    }
}
