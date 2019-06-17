using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    class MeczSiatkowki : Mecz
    {
        Sedzia[] sedziowiePomocniczy;

        public MeczSiatkowki(Druzyna d1, Druzyna d2, Sedzia sd, int stM, Sedzia sp1, Sedzia sp2) : base(d1, d2, sd, stM)
        {
            sedziowiePomocniczy = new Sedzia[2];
            sedziowiePomocniczy[0] = sp1;
            sedziowiePomocniczy[1] = sp2;
        }
        public MeczSiatkowki(Druzyna d1, Druzyna d2, Sedzia sd, int stM, Sedzia sp1, Sedzia sp2, int w1, int w2) : base(d1, d2, sd, stM, w1, w2)
        {
            sedziowiePomocniczy = new Sedzia[2];
            sedziowiePomocniczy[0] = sp1;
            sedziowiePomocniczy[1] = sp2;
        }
        public Sedzia[] getSedziowiePomocniczy() => sedziowiePomocniczy;
    }
}
