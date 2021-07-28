using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Fuzzy
{
    class FMath
    {
        public static double OR(double p, params IFuzzySet[] sets)
        {
            double ret = sets[0].GetValueInPoint(p);
            foreach (IFuzzySet set in sets)
            {
                double val = set.GetValueInPoint(p);
                if (val > ret) { ret = val; }
            }
            return ret;
        }

        public static double AND(double p, params IFuzzySet[] sets)
        {
            double ret = sets[0].GetValueInPoint(p);
            foreach (IFuzzySet set in sets)
            {
                double val = set.GetValueInPoint(p);
                if (val < ret) { ret = val; }
            }
            return ret;
        }
        public static double NOT(double p, IFuzzySet set)
        {
            return -set.GetValueInPoint(p);
        }
    }
}
