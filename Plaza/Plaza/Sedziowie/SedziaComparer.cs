using System.Collections.Generic;

namespace Plaza
{
    /// <summary>
    /// Klasa określająca porównywanie sędziów
    /// </summary>
    class SedziaComparer : Comparer<Sedzia>
    {
        /// <summary>
        /// Porównywanie sędziów
        /// </summary>
        /// <param name="x">parametr określający liczbę sędziowanych meczy jednego sędziego</param>
        /// <param name="y">parametr określający liczbę sędziowanych meczy drugiego sędziego</param>
        /// <returns></returns>
        public override int Compare(Sedzia x, Sedzia y)
        {
            if (object.Equals(x, y)) return 0;
            return y.IloscSedziowanychMeczow.CompareTo(x.IloscSedziowanychMeczow);
        }
    }
}
