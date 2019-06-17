namespace Plaza
{
    /// <summary>
    /// Klasa opisująca zawodnika
    /// </summary>
    class Zawodnik
    {
        /// <summary>
        /// pola opisujące zawodnika
        /// </summary>
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
        /// <summary>
        /// Konstruktor roku urodzenia zawodnika
        /// </summary>
        public int RokUrodzenia => rokUrodzenia;
        /// <summary>
        /// Konstruktor drużyny
        /// </summary>
        internal Druzyna Druzyna { get => druzyna; set => druzyna = value; }
        /// <summary>
        /// Budowa zawodnika
        /// </summary>
        /// <param name="i">parametr określający imię zawodnika</param>
        /// <param name="n">parametr określający nazwisko zawodnika</param>
        /// <param name="d">parametr określający rok urodzenia zawodnika</param>
        /// <param name="dr">parametr określający drużynę zawodnika</param>
        public Zawodnik(string i, string n, int d, Druzyna dr)
        {
            imie = i;
            nazwisko = n;
            rokUrodzenia = d;
            druzyna = dr;
        }
        /// <summary>
        /// Pobieranie imienia
        /// </summary>
        /// <returns>Zwracanie imienia</returns>
        public string GetImie() => imie;
        /// <summary>
        /// Pobieranie nazwiska zawodnika
        /// </summary>
        /// <returns>Zwracanie nazwiska zawodnika</returns>
        public string GetNazwisko() => nazwisko;
        /// <summary>
        /// Pobieranie drużyny
        /// </summary>
        /// <returns>Zwracanie drużyny</returns>
        public Druzyna GetDruzyna() => druzyna;
    }
}
