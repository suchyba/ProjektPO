using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    /**
     * <summary>Jest to klasa opisująca drużynę grającą w przeciąganie liny.</summary>
     */
    class DruzynaPrzeciaganieLiny : Druzyna
    {
        public DruzynaPrzeciaganieLiny(string n, int r, string o) : base(n, r, o)
        {

        }
        public DruzynaPrzeciaganieLiny(string n, int r, string o, string[] zawodnicy) : base(n, r, o, zawodnicy)
        {

        }
    }
}
