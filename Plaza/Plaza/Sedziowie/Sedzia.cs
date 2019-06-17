using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    /// <summary>
    /// Klasa określająca sędziego
    /// </summary>
    class Sedzia
    {
        /// <summary>
        /// pola odpowiedzialne za sędziego
        /// </summary>
        string imie;
        string nazwisko;
        int wiek;
        string numerLicencji;
        int liczbaSedziowanychMeczow;

        /// <summary>
        /// Budowa sędziego
        /// </summary>
        /// <param name="i">parametr określający imię sędziego</param>
        /// <param name="n">parametr określający nazwisko sędziego</param>
        /// <param name="w">parametr określający wiek sędziego</param>
        /// <param name="num">parametr określający numer licencji sędziego</param>
        public Sedzia(string i, string n, int w, string num)
        {
            imie = i;
            nazwisko = n;
            wiek = w;
            numerLicencji = num;
        }

        /// <summary>
        /// Zwracanie imienia
        /// </summary>
        public string Imie => imie;
        /// <summary>
        /// Zwracanie nazwiska
        /// </summary>
        public string Nazwisko => nazwisko;
        /// <summary>
        /// Zwracanie imienia oraz nazwiska
        /// </summary>
        public string ImieNazwisko => imie + " " + nazwisko;
        /// <summary>
        /// Zwracanie wieku
        /// </summary>
        public int Wiek => wiek;
        /// <summary>
        /// Zwracanie numeru licencji
        /// </summary>
        public string NumerLicencji => numerLicencji;
        /// <summary>
        /// Zwracanie ilosci sędziowanych meczów
        /// </summary>
        public int IloscSedziowanychMeczow => liczbaSedziowanychMeczow;
        /// <summary>
        /// Zwracanie zwiększonej liczby sędziowanych meczów
        /// </summary>
        public void ZwiekszIloscMeczow() => ++liczbaSedziowanychMeczow;
    }
}
