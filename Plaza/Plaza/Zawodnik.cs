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
        int rokUrodzenia;
        Druzyna druzyna;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public int RokUrodzenia => rokUrodzenia;
        internal Druzyna Druzyna { get => druzyna; set => druzyna = value; }

        public Zawodnik(string i, string n, int d, Druzyna dr)
        {
            imie = i;
            nazwisko = n;
            rokUrodzenia = d;
            druzyna = dr;
        }
        public string GetImie() => imie;
        public string GetNazwisko() => nazwisko;
        public Druzyna GetDruzyna() => druzyna;
    }
}
