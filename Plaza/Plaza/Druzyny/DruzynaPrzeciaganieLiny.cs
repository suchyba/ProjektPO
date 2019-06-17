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
        /// <summary>
        /// Zwracanie sportu "Przeciąganie liny"
        /// </summary>
        public override string Sport => "Przeciąganie liny";
        /// <summary>
        /// Budowa drużyny od przeciągania liny
        /// </summary>
        /// <param name="n">parametr określający nazwę drużyny od przeciągania liny</param>
        /// <param name="r">parametr określający rok powstania drużyny od przeciągania liny</param>
        /// <param name="o">parametr określający opis drużyny od przeciągania liny</param>
        public DruzynaPrzeciaganieLiny(string n, int r, string o) : base(n, r, o)
        {

        }
       /* public override string ToString()
        {
            return "Przeciąganie Liny";
        }*/
    }
}
