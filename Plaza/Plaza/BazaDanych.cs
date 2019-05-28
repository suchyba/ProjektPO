using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    class BazaDanych
    {
        List<Druzyna> listaDruzyn;
        List<Mecz> listaMeczy;
        List<Zawodnik> listaZawodnikow;
        List<Sedzia> listaSedziow;

        public BazaDanych()
        {
            listaDruzyn = new List<Druzyna>();
            listaMeczy = new List<Mecz>();
            listaZawodnikow = new List<Zawodnik>();
        }

        public void ZglosDruzyne(Druzyna d) => listaDruzyn.Add(d);
        public void WycofajDruzyne(string nazwa) => listaDruzyn.Remove(listaDruzyn.Where(d => d.GetNazwa() == nazwa).FirstOrDefault());
        public List<Druzyna> GetListaDruzyn() => listaDruzyn;
        public void GenerujFinaly()
        {

        }
        public void GenerujPolfinaly()
        {

        }
        public void DodajMecz(Mecz m) => listaMeczy.Add(m);
        public void RozegrajMecz(int numerMeczu, int w1, int w2) => listaMeczy[numerMeczu].UstawWyniki(w1, w2);
        public void DodajSedziego(Sedzia s)
        {
            listaSedziow.Add(s);
        }
        public void UsunSedziego(string numerLicencji)
        {

        }
    }
}
