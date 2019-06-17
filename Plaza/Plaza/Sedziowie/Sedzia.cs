namespace Plaza
{
    /// <summary>
    /// Klasa określająca sędziego
    /// </summary>
    class Sedzia
    {
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

        public string Imie => imie;
        public string Nazwisko => nazwisko;
        public string ImieNazwisko => imie + " " + nazwisko;
        public int Wiek => wiek;
        public string NumerLicencji => numerLicencji;
        public int IloscSedziowanychMeczow => liczbaSedziowanychMeczow;
        public void ZwiekszIloscMeczow() => ++liczbaSedziowanychMeczow;
    }
}
