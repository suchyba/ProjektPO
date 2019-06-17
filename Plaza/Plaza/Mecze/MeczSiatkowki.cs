namespace Plaza
{
    /// <summary>
    /// Klasa określająca mecz siatkówki
    /// </summary>
    class MeczSiatkowki : Mecz
    {
        Sedzia[] sedziowiePomocniczy;
        /// <summary>
        /// Imiona i nazwiska dwóch sędziów pomocniczych
        /// </summary>
        public string SedziowiePomocniczy => sedziowiePomocniczy[0].ImieNazwisko + "\n" + sedziowiePomocniczy[1].ImieNazwisko;
        /// <summary>
        /// Konstruowanie meczu siatkówki
        /// </summary>
        /// <param name="d1">parametr określający drużynę pierwszą</param>
        /// <param name="d2">parametr określający drużynę drugą</param>
        /// <param name="sd">parametr określający sędziego głównego</param>
        /// <param name="stM">parametr określający stopień meczu</param>
        /// <param name="sp1">parametr określający pierwszego sędziego pomocniczego</param>
        /// <param name="sp2">parametr określający drugiego sędziego pomocniczego</param>
        public MeczSiatkowki(Druzyna d1, Druzyna d2, Sedzia sd, int stM, Sedzia sp1, Sedzia sp2) : base(d1, d2, sd, stM)
        {
            sedziowiePomocniczy = new Sedzia[2];
            sedziowiePomocniczy[0] = sp1;
            sedziowiePomocniczy[1] = sp2;
        }
        /// <summary>
        /// Konstruowanie meczu siatkówki
        /// </summary>
        /// <param name="d1">parametr określający drużynę pierwszą</param>
        /// <param name="d2">parametr określający drużynę drugą</param>
        /// <param name="sd">parametr określający sędziego głównego</param>
        /// <param name="stM">parametr określający stopień meczu</param>
        /// <param name="sp1">parametr określający pierwszego sędziego pomocniczego</param>
        /// <param name="sp2">parametr określający drugiego sędziego pomocniczego</param>
        /// <param name="w1">parametr określający wynik pierwszej drużyny</param>
        /// <param name="w2">parametr określający wynik drugiej drużyny</param>
        public MeczSiatkowki(Druzyna d1, Druzyna d2, Sedzia sd, int stM, Sedzia sp1, Sedzia sp2, int w1, int w2) : base(d1, d2, sd, stM, w1, w2)
        {
            sedziowiePomocniczy = new Sedzia[2];
            sedziowiePomocniczy[0] = sp1;
            sedziowiePomocniczy[1] = sp2;
        }
        /// <summary>
        /// Pobieranie sędziów pomocniczych
        /// </summary>
        /// <returns>zwraca sędziów pomocniczych</returns>
        public Sedzia[] getSedziowiePomocniczy() => sedziowiePomocniczy;
    }
}
