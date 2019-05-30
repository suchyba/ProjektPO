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
        public void GenerujFinaly(Sporty sport)
        {

        }
        public void GenerujPolfinaly(Sporty sport)
        {
            listaDruzyn.Sort(new DruzynaComparer());
            listaSedziow.Sort(new SedziaComparer());

            int liczbaDodanych = 0;
            Druzyna d1 = null;

            foreach (var druzyna in listaDruzyn)
            {
                switch (sport)
                {
                    case Sporty.Siatkowka:
                        {
                            if(druzyna is DruzynaSiatkowka && d1 == null)
                                 d1 = druzyna;
                            else if(druzyna is DruzynaSiatkowka)
                            {
                                DodajMecz(new MeczSiatkowki(d1, druzyna, listaSedziow[0], (int)StopienMeczu.MeczPolfinalowy, listaSedziow[1], listaSedziow[2]));
                                d1 = null;
                                ++liczbaDodanych;
                            }
                            break;
                        }
                    case Sporty.PrzeciaganieLiny:
                        {
                            if (druzyna is DruzynaPrzeciaganieLiny && d1 == null)
                                d1 = druzyna;
                            else if(druzyna is DruzynaPrzeciaganieLiny)
                            {
                                DodajMecz(new Mecz(d1, druzyna, listaSedziow[0], (int)StopienMeczu.MeczPolfinalowy));
                                d1 = null;
                                ++liczbaDodanych;
                            }
                            break;
                        }
                    case Sporty.DwaOgnie:
                        {
                            if (druzyna is DruzynaDwaOgnie && d1 == null)
                                d1 = druzyna;
                            else if(druzyna is DruzynaDwaOgnie && d1 == null)
                            {
                                DodajMecz(new Mecz(d1, druzyna, listaSedziow[0], (int)StopienMeczu.MeczPolfinalowy));
                                d1 = null;
                                ++liczbaDodanych;
                            }
                            break;
                        }
                    default:
                        break;
                }
                if (liczbaDodanych == 4)
                    return;
            }
        }
        public void DodajMecz(Mecz m) => listaMeczy.Add(m);
        public void RozegrajMecz(int numerMeczu, int w1, int w2) => listaMeczy[numerMeczu].UstawWyniki(w1, w2);
        public void DodajSedziego(Sedzia s) => listaSedziow.Add(s);
        public void UsunSedziego(string numerLicencji) => listaSedziow.Remove(listaSedziow.Where(s => s.GetNumerLicencji() == numerLicencji).FirstOrDefault());

    }
}
