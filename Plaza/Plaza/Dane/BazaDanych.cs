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
        /// Baza z listami dru�yn, mecz�w, zawodnik�w, s�dzi�w
        /// </summary>
        public BazaDanych()
        {
            listaDruzyn = new List<Druzyna>();
            listaMeczy = new List<Mecz>();
            listaZawodnikow = new List<Zawodnik>();
            listaSedziow = new List<Sedzia>();
        }
        /// <summary>
        /// Dodawanie dru�yny
        /// </summary>
        /// <param name="d">parametr okre�laj�cy dru�yn�</param>
        public void ZglosDruzyne(Druzyna d) => listaDruzyn.Add(d);
        /// <summary>
        /// Usuwanie dru�yny
        /// </summary>
        /// <param name="druzyna">parametr okre�laj�cy dru�yn�</param>
        public void WycofajDruzyne(Druzyna druzyna) => listaDruzyn.Remove(druzyna);
        /// <summary>
        /// Pobieranie listy dru�yn
        /// </summary>
        /// <returns>Zwraca list� dru�yn</returns>
        public List<Druzyna> GetListaDruzyn() => listaDruzyn;
        /// <summary>
        /// Generowanie fina��w
        /// </summary>
        /// <param name="sport">Parametr okre�laj�cy sport, dla kt�rego s� generowane fina�y</param>
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
        /// Generowanie p�fina��w dla sport�w
        /// </summary>
        /// <param name="sport">Parametr okre�laj�cy sport, dla kt�rego s� generowane p�fina�y</param>
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
        /// <param name="w1">Wynik pierwszej dru�yny</param>
        /// <param name="w2">Wynik drugiej dru�yny</param>
        public void RozegrajMecz(int numerMeczu, int w1, int w2) => listaMeczy[numerMeczu].UstawWyniki(w1, w2);
        /// <summary>
        /// Dodawanie s�dziego
        /// </summary>
        /// <param name="s">Dodawany s�dzia</param>
        public void DodajSedziego(Sedzia s) => listaSedziow.Add(s);
        /// <summary>
        /// Usuwanie s�dziego
        /// </summary>
        /// <param name="numerLicencji">parametr okre�laj�cy numer licencji s�dziego</param>
        public void UsunSedziego(string numerLicencji) => listaSedziow.Remove(listaSedziow.Where(s => s.NumerLicencji== numerLicencji).FirstOrDefault());
        /// <summary>
        /// Pobieranie listy meczy
        /// </summary>
        /// <returns>zwraca list� meczy</returns>
        public List<Mecz> GetListaMeczy() => listaMeczy;
        /// <summary>
        /// Pobieranie listy s�dzi�w
        /// </summary>
        /// <returns>zwraca list� s�dzi�w</returns>
        public List<Sedzia> GetListaSedziow() => listaSedziow;
        /// <summary>
        /// Pobiera list� zawodnik�w
        /// </summary>
        /// <returns>zwraca list� zawodnik�w</returns>
        public List<Zawodnik> GetListaZawodnikow() => listaZawodnikow;
        /// <summary>
        /// Dodawanie zawodnika
        /// </summary>
        /// <param name="imie">imi� zawodnika</param>
        /// <param name="nazwisko">nazwisko zawodnika</param>
        /// <param name="dataUrodzenia">data urodzenia zawodnika</param>
        /// <param name="druzyna">dru�yna, do kt�rej nale�y zawodnik</param>
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
