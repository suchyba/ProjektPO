namespace Plaza
{
    /// <summary>
    /// Klasa opisująca druzynę grającą w siatkówkę.
    /// </summary>
    class DruzynaSiatkowka : Druzyna
    {
        /// <summary>
        /// Opis drużyny siatkówki
        /// </summary>
        /// <param name="n">parametr określający nazwę drużyny siatkówki</param>
        /// <param name="r">parametr określający rok powstania drużyny siatkówki</param>
        /// <param name="o">parametr określający opis drużyny siatkówki</param>
        public override string Sport => "Siatkówka";
        public DruzynaSiatkowka(string n, int r, string o) : base(n, r, o)
        {

        }
        /*public override string ToString()
        {
            return "Siatkówka";
        }*/
    }
}
