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
            listaSedziow = new List<Sedzia>();
        }

        public void ZglosDruzyne(Druzyna d) => listaDruzyn.Add(d);
        public void WycofajDruzyne(string nazwa) => listaDruzyn.Remove(listaDruzyn.Where(d => d.GetNazwa() == nazwa).FirstOrDefault());
        public List<Druzyna> GetListaDruzyn() => listaDruzyn;
        public void GenerujFinaly(Sporty sport)
        {
            listaSedziow.Sort(new SedziaComparer());
            switch (sport)
            {
                case Sporty.Siatkowka:
                    {
                        List<Mecz> listaMeczowPolfinalowych = (List<Mecz>)listaMeczy.Where(m => m.GetStopienMeczu() == (int)StopienMeczu.MeczPolfinalowy && m.GetDruzyny()[0] is DruzynaSiatkowka);
                        Druzyna d1, d2;
                        d1 = listaMeczowPolfinalowych[0].GetWynik()[0] > listaMeczowPolfinalowych[0].GetWynik()[1] ? listaMeczowPolfinalowych[0].GetDruzyny()[0] : listaMeczowPolfinalowych[0].GetDruzyny()[1];
                        d2 = listaMeczowPolfinalowych[1].GetWynik()[0] > listaMeczowPolfinalowych[1].GetWynik()[1] ? listaMeczowPolfinalowych[1].GetDruzyny()[0] : listaMeczowPolfinalowych[1].GetDruzyny()[1];
                        DodajMecz(new MeczSiatkowki(d1, d2, listaSedziow[0], (int)StopienMeczu.MeczFinalowy, listaSedziow[1], listaSedziow[2]));
                        break;
                    }
                case Sporty.PrzeciaganieLiny:
                    {
                        List<Mecz> listaMeczowPolfinalowych = (List<Mecz>)listaMeczy.Where(m => m.GetStopienMeczu() == (int)StopienMeczu.MeczPolfinalowy && m.GetDruzyny()[0] is DruzynaPrzeciaganieLiny);
                        Druzyna d1, d2;
                        d1 = listaMeczowPolfinalowych[0].GetWynik()[0] > listaMeczowPolfinalowych[0].GetWynik()[1] ? listaMeczowPolfinalowych[0].GetDruzyny()[0] : listaMeczowPolfinalowych[0].GetDruzyny()[1];
                        d2 = listaMeczowPolfinalowych[1].GetWynik()[0] > listaMeczowPolfinalowych[1].GetWynik()[1] ? listaMeczowPolfinalowych[1].GetDruzyny()[0] : listaMeczowPolfinalowych[1].GetDruzyny()[1];
                        DodajMecz(new Mecz(d1, d2, listaSedziow[0], (int)StopienMeczu.MeczFinalowy));
                        break;
                    }
                case Sporty.DwaOgnie:
                    {
                        List<Mecz> listaMeczowPolfinalowych = (List<Mecz>)listaMeczy.Where(m => m.GetStopienMeczu() == (int)StopienMeczu.MeczPolfinalowy && m.GetDruzyny()[0] is DruzynaDwaOgnie);
                        Druzyna d1, d2;
                        d1 = listaMeczowPolfinalowych[0].GetWynik()[0] > listaMeczowPolfinalowych[0].GetWynik()[1] ? listaMeczowPolfinalowych[0].GetDruzyny()[0] : listaMeczowPolfinalowych[0].GetDruzyny()[1];
                        d2 = listaMeczowPolfinalowych[1].GetWynik()[0] > listaMeczowPolfinalowych[1].GetWynik()[1] ? listaMeczowPolfinalowych[1].GetDruzyny()[0] : listaMeczowPolfinalowych[1].GetDruzyny()[1];
                        DodajMecz(new Mecz(d1, d2, listaSedziow[0], (int)StopienMeczu.MeczFinalowy));
                        break;
                    }
                default:
                    break;
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sport">Sport dla którego generujemy pó³fina³y</param>
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
                            else if(druzyna is DruzynaDwaOgnie)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        public void DodajMecz(Mecz m) => listaMeczy.Add(m);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numerMeczu"></param>
        /// <param name="w1"></param>
        /// <param name="w2"></param>
        public void RozegrajMecz(int numerMeczu, int w1, int w2) => listaMeczy[numerMeczu].UstawWyniki(w1, w2);
        public void DodajSedziego(Sedzia s) => listaSedziow.Add(s);
        public void UsunSedziego(string numerLicencji) => listaSedziow.Remove(listaSedziow.Where(s => s.NumerLicencji== numerLicencji).FirstOrDefault());
        public List<Mecz> GetListaMeczy() => listaMeczy;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Sedzia> GetListaSedziow() => listaSedziow;
        public List<Zawodnik> GetListaZawodnikow() => listaZawodnikow;
        public void DodajZawodnika(string imie, string nazwisko, int rokUrodzenia, Druzyna druzyna)
        {
            listaZawodnikow.Add(new Zawodnik(imie, nazwisko, rokUrodzenia, druzyna));
        }
        public void UsunZawodnika(Zawodnik zawodnik)
        {
            listaZawodnikow.Remove(zawodnik);
        }
    }
}
