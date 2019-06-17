namespace Plaza
{
    /// <summary>
    /// Klasa opisująca drużynę grającą w dwa ognie
    /// </summary>
    class DruzynaDwaOgnie : Druzyna
    {
        /// <summary>
        /// Zwracanie sportu "Dwa ognie"
        /// </summary>
        public override string Sport => "Dwa ognie";
        /// <summary>
        /// Budowa drużyny od dwóch ogni
        /// </summary>
        /// <param name="n">parametr określający nazwę drużyny od dwóch ogni</param>
        /// <param name="r">parametr określający rok powstania drużyny od dwóch ogni</param>
        /// <param name="o">parametr określający opis drużyny od dwóch ogni</param>
        public DruzynaDwaOgnie(string n, int r, string o) : base(n, r, o)
        {

        }
        /*public override string ToString()
        {
            return "Dwa Ognie";
        }*/
    }
}
