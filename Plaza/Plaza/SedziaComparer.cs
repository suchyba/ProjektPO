using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    class SedziaComparer : Comparer<Sedzia>
    {
        public override int Compare(Sedzia x, Sedzia y)
        {
            if (object.Equals(x, y)) return 0;
            return x.GetIloscSedziowanychMeczow().CompareTo(y.GetIloscSedziowanychMeczow());
        }
    }
}
