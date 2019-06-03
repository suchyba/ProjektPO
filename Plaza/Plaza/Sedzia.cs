using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    class Sedzia
    {
        string imie;
        string nazwisko;
        int wiek;
        string numerLicencji;
        int liczbaSedziowanychMeczow;

        public Sedzia(string i, string n, int w, string num)
        {
            imie = i;
            nazwisko = n;
            wiek = w;
            numerLicencji = num;
        }

        public string Imie => imie;
        public string Nazwisko => nazwisko;
        public string ImieNazwisko => imie + " " + nazwisko;
        public int Wiek => wiek;
        public string NumerLicencji => numerLicencji;
        public int IloscSedziowanychMeczow => liczbaSedziowanychMeczow;
    }
}
