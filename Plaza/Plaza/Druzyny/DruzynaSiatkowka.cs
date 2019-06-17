using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    /// <summary>
    /// Klasa opisująca druzynę grającą w siatkówkę.
    /// </summary>
    class DruzynaSiatkowka : Druzyna
    {
        public override string Sport => "Siatkówka";
        public DruzynaSiatkowka(string n, int r, string o) : base(n, r, o)
        {

        }
        /*public override string ToString()
        {
            return "Siatkówka";
        }*/
    }
}
