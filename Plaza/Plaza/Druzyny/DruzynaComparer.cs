using System.Collections.Generic;

namespace Plaza
{
    /// <summary>
    /// Klasa porównująca drużyny
    /// </summary>
    class DruzynaComparer : Comparer<Druzyna>
    {
        /// <summary>
        /// Porównanie punktów drużyn
        /// </summary>
        /// <param name="x">parametr określający liczbę punktów jednej drużyny</param>
        /// <param name="y">parametr określający liczbę punktów drugiej drużyny</param>
        /// <returns></returns>
        public override int Compare(Druzyna x, Druzyna y)
        {
            if (object.Equals(x, y)) return 0;
            return y.GetPunkty().CompareTo(x.GetPunkty());
        }
    }
}
