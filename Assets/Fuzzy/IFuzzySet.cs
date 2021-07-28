using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Fuzzy
{
    interface IFuzzySet
    {
        double GetValueInPoint(double p);
    }
}
