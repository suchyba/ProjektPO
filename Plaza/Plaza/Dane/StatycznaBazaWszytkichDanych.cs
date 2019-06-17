namespace Plaza.Technologie_Testowe
{
    /// <summary>
    /// Klasa opisująca statyczną bazę wszystkich danych
    /// </summary>
    static class StatycznaBazaWszytkichDanych
    {
        /// <summary>
        /// Tworzenie nowej bazy danych
        /// </summary>
        static readonly BazaDanych baza = new BazaDanych();
        /// <summary>
        /// Pobieranie bazy
        /// </summary>
        /// <returns>zwraca bazę</returns>
        public static BazaDanych GetBaza() => baza;

    }
}
