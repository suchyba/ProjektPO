using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    class BazaDruzyn
    {
        List<Druzyna> listaDruzyn;
        List<Mecz> listaMeczy;

        public BazaDruzyn()
        {
            listaDruzyn = new List<Druzyna>();
            listaMeczy = new List<Mecz>();
        }

        public void ZglosDruzyne(Druzyna d)
        {
            listaDruzyn.Add(d);
        }
        public void WycofajDruzyne(string nazwa)
        {
            listaDruzyn.Remove(listaDruzyn.Where(d => d.GetNazwa() == nazwa).FirstOrDefault());
        }
        public void GenerujFinaly()
        {

        }
        public void GenerujPolfinaly()
        {

        }
    }
}
