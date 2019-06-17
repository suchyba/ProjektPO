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
        /// <summary>
        /// Baza z listami dru¿yn, meczów, zawodników, sêdziów
        /// </summary>
        public BazaDanych()
        {
            listaDruzyn = new List<Druzyna>();
            listaMeczy = new List<Mecz>();
            listaZawodnikow = new List<Zawodnik>();
            listaSedziow = new List<Sedzia>();
        }
        /// <summary>
        /// Dodawanie dru¿yny
        /// </summary>
        /// <param name="d">parametr okreœlaj¹cy dru¿ynê</param>
        public void ZglosDruzyne(Druzyna d) => listaDruzyn.Add(d);
        /// <summary>
        /// Usuwanie dru¿yny
        /// </summary>
        /// <param name="nazwa">parametr okreœlaj¹cy nazwê dru¿yny</param>
        public void WycofajDruzyne(string nazwa) => listaDruzyn.Remove(listaDruzyn.Where(d => d.GetNazwa() == nazwa).FirstOrDefault());
        /// <summary>
        /// Pobieranie listy dru¿yn
        /// </summary>
        /// <returns>Zwraca listê dru¿yn</returns>
        public List<Druzyna> GetListaDruzyn() => listaDruzyn;
        /// <summary>
        /// Generowanie fina³ów
        /// </summary>
        /// <param name="sport">Parametr okreœlaj¹cy sport, dla którego s¹ generowane fina³y</param>
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
        /// Generowanie pó³fina³ów dla sportów
        /// </summary>
        /// <param name="sport">Parametr okreœlaj¹cy sport, dla którego s¹ generowane pó³fina³y</param>
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
        /// Dodawanie meczu
        /// </summary>
        /// <param name="m">Dodawany mecz</param>
        public void DodajMecz(Mecz m) => listaMeczy.Add(m);
        /// <summary>
        /// Rozgrywanie meczu
        /// </summary>
        /// <param name="numerMeczu">Numer meczu</param>
        /// <param name="w1">Wynik pierwszej dru¿yny</param>
        /// <param name="w2">Wynik drugiej dru¿yny</param>
        public void RozegrajMecz(int numerMeczu, int w1, int w2) => listaMeczy[numerMeczu].UstawWyniki(w1, w2);
        /// <summary>
        /// Dodawanie sêdziego
        /// </summary>
        /// <param name="s">Dodawany sêdzia</param>
        public void DodajSedziego(Sedzia s) => listaSedziow.Add(s);
        /// <summary>
        /// Usuwanie sêdziego
        /// </summary>
        /// <param name="numerLicencji">parametr okreœlaj¹cy numer licencji sêdziego</param>
        public void UsunSedziego(string numerLicencji) => listaSedziow.Remove(listaSedziow.Where(s => s.NumerLicencji== numerLicencji).FirstOrDefault());
        /// <summary>
        /// Pobieranie listy meczy
        /// </summary>
        /// <returns>zwraca listê meczy</returns>
        public List<Mecz> GetListaMeczy() => listaMeczy;
        /// <summary>
        /// Pobieranie listy sêdziów
        /// </summary>
        /// <returns>zwraca listê sêdziów</returns>
        public List<Sedzia> GetListaSedziow() => listaSedziow;
        /// <summary>
        /// Pobiera listê zawodników
        /// </summary>
        /// <returns>zwraca listê zawodników</returns>
        public List<Zawodnik> GetListaZawodnikow() => listaZawodnikow;
        /// <summary>
        /// Dodawanie zawodnika
        /// </summary>
        /// <param name="imie">imiê zawodnika</param>
        /// <param name="nazwisko">nazwisko zawodnika</param>
        /// <param name="dataUrodzenia">data urodzenia zawodnika</param>
        /// <param name="druzyna">dru¿yna, do której nale¿y zawodnik</param>
        public void DodajZawodnika(string imie, string nazwisko, DateTime dataUrodzenia, Druzyna druzyna)
        {
            listaZawodnikow.Add(new Zawodnik(imie, nazwisko, dataUrodzenia, druzyna));
        }
    }
}
