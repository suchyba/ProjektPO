﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    class DruzynaComparer : Comparer<Druzyna>
    {
        public override int Compare(Druzyna x, Druzyna y)
        {
            if (object.Equals(x, y))    return 0;
            return x.GetPunkty().CompareTo(y.GetPunkty());
        }
    }
}
