using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    class Zawodnik
    {
        string imie;
        string nazwisko;
        DateTime dataUrodzenia;
        Druzyna druzyna;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        internal Druzyna Druzyna { get => druzyna; set => druzyna = value; }

        public Zawodnik(string i, string n, DateTime d, Druzyna dr)
        {
            imie = i;
            nazwisko = n;
            dataUrodzenia = d;
            druzyna = dr;
        }
        public Zawodnik(string i, string n, int dzien, int miesiac, int rok, Druzyna dr) : this(i, n, new DateTime(rok, miesiac, dzien), dr)
        {

        }
        public string GetImie() => imie;
        public string GetNazwisko() => nazwisko;
        public DateTime GetDataUrodzenia() => dataUrodzenia;
        public Druzyna GetDruzyna() => druzyna;
    }
}
