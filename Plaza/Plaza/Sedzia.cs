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

        public Sedzia(string i, string n, int w, string num)
        {
            imie = i;
            nazwisko = n;
            wiek = w;
            numerLicencji = num;
        }

        public string GetImie()
        {
            return imie;
        }
        public string GetNazwisko()
        {
            return nazwisko;
        }
        public int GetWiek()
        {
            return wiek;
        }
        public string GetNumerLicencji()
        {
            return numerLicencji;
        }
    }
}
