using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    /// <summary>
    /// Klasa opisująca zawodnika
    /// </summary>
    class Zawodnik
    {
        string imie;
        string nazwisko;
        DateTime dataUrodzenia;
        Druzyna druzyna;
        /// <summary>
        /// Konstruktor imienia zawodnika
        /// </summary>
        public string Imie { get => imie; set => imie = value; }
        /// <summary>
        /// Konstruktor nazwiska zawodnika
        /// </summary>
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        //public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        /// <summary>
        /// Konstruktor daty urodzenia zawodnika
        /// </summary>
        public string DataUrodzenia => dataUrodzenia.ToLongDateString();
        /// <summary>
        /// Konstruktor drużyny
        /// </summary>
        internal Druzyna Druzyna { get => druzyna; set => druzyna = value; }
        /// <summary>
        /// Budowa zawodnika
        /// </summary>
        /// <param name="i">parametr opisujący imię zawodnika</param>
        /// <param name="n">parametr opisujący nazwisko zawodnika</param>
        /// <param name="d">parametr opisujący datę urodzenia zawodnika</param>
        /// <param name="dr">parametr opisujący drużynę zawodnika</param>
        public Zawodnik(string i, string n, DateTime d, Druzyna dr)
        {
            imie = i;
            nazwisko = n;
            dataUrodzenia = d;
            druzyna = dr;
        }
        /// <summary>
        /// Opis zawodnika
        /// </summary>
        /// <param name="i">parametr opisujący imię zawodnika</param>
        /// <param name="n">parametr opisujący nazwisko zawodnika</param>
        /// <param name="dzien">parametr opisujący dzień urodzenia zawodnika</param>
        /// <param name="miesiac">parametr opisujący miesiąc urodzenia zawodnika</param>
        /// <param name="rok">parametr opisujący rok urodzenia zawodnika</param>
        /// <param name="dr">parametr opisujący drużynę zawodnika</param>
        public Zawodnik(string i, string n, int dzien, int miesiac, int rok, Druzyna dr) : this(i, n, new DateTime(rok, miesiac, dzien), dr)
        {

        }
        /// <summary>
        /// Pobieranie imienia zawodnika
        /// </summary>
        /// <returns>zwraca imię zawodnika</returns>
        public string GetImie() => imie;
        /// <summary>
        /// Pobieranie nazwiska zawodnika
        /// </summary>
        /// <returns>zwraca nazwisko zawodnika</returns>
        public string GetNazwisko() => nazwisko;
        /// <summary>
        /// Pobieranie daty urodzenia zawodnika
        /// </summary>
        /// <returns>zwraca datę urodzenia zawodnika</returns>
        public DateTime GetDataUrodzenia() => dataUrodzenia;
        /// <summary>
        /// Pobiera drużynę zawodnika
        /// </summary>
        /// <returns>zwraca drużynę zawodnika</returns>
        public Druzyna GetDruzyna() => druzyna;
    }
}
