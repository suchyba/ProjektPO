namespace Plaza
{
    /// <summary>
    /// Klasa opisująca drużynę grającą w przeciąganie liny
    /// </summary>
    class DruzynaPrzeciaganieLiny : Druzyna
    {
        /// <summary>
        /// Budowa drużyny od przeciągania liny
        /// </summary>
        /// <param name="n">parametr określający nazwę drużyny od przeciągania liny</param>
        /// <param name="r">parametr określający rok powstania drużyny od przeciągania liny</param>
        /// <param name="o">parametr określający opis drużyny od przeciągania liny</param>
        public override string Sport => "Przeciąganie liny";
        public DruzynaPrzeciaganieLiny(string n, int r, string o) : base(n, r, o)
        {

        }
        /* public override string ToString()
         {
             return "Przeciąganie Liny";
         }*/
    }
}
