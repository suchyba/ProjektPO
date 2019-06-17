using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    /// <summary>
    /// Klasa opisująca drużynę grającą w przeciąganie liny
    /// </summary>
    class DruzynaPrzeciaganieLiny : Druzyna
    {
        public override string Sport => "Przeciąganie liny";
        public DruzynaPrzeciaganieLiny(string n, int r, string o) : base(n, r, o)
        {

        }
       /* public override string ToString()
        {
            return "Przeciąganie Liny";
        }*/
    }
}
