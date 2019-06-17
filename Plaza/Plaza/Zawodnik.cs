namespace Plaza
{
    /// <summary>
    /// Klasa opisująca zawodnika
    /// </summary>
    class Zawodnik
    {
        string imie;
        string nazwisko;
        int rokUrodzenia;
        Druzyna druzyna;
        /// <summary>
        /// Konstruktor imienia zawodnika
        /// </summary>
        public string Imie { get => imie; set => imie = value; }
        /// <summary>
        /// Konstruktor nazwiska zawodnika
        /// </summary>
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public int RokUrodzenia => rokUrodzenia;
        /// <summary>
        /// Konstruktor drużyny
        /// </summary>
        internal Druzyna Druzyna { get => druzyna; set => druzyna = value; }

        public Zawodnik(string i, string n, int d, Druzyna dr)
        {
            imie = i;
            nazwisko = n;
            rokUrodzenia = d;
            druzyna = dr;
        }
        public string GetImie() => imie;
        /// <summary>
        /// Pobieranie nazwiska zawodnika
        /// </summary>
        /// <returns>zwraca nazwisko zawodnika</returns>
        public string GetNazwisko() => nazwisko;
        public Druzyna GetDruzyna() => druzyna;
    }
}
