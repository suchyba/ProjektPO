using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    enum Sporty
    {
        Siatkowka = 0, PrzeciaganieLiny = 1, DwaOgnie = 2
    }
    /// <summary>
    /// Klasa określająca drużyny
    /// </summary>
    class Druzyna
    {
        protected string nazwa;
        protected int rokPowstania;
        protected string opis;
        protected int punkty;

        public string Nazwa { get => nazwa; set { nazwa = value; } }
        public int RokPowstania => rokPowstania;
        public string Opis => opis;
        public int Punkty => punkty;



        /// <summary>
        /// Budowa drużyny
        /// </summary>
        /// <param name="n">parametr określający nazwę drużyny</param>
        /// <param name="r">parametr określający rok powstania drużyny</param>
        /// <param name="o">parametr określający opis drużyny</param>
        public Druzyna(string n, int r, string o)
        {
            nazwa = n;
            rokPowstania = r;
            opis = o;
        }
        /// <summary>
        /// Pobieranie nazwy drużyny
        /// </summary>
        /// <returns>zwraca nazwę drużyny</returns>
        public string GetNazwa() => nazwa;
        /// <summary>
        /// Pobieranie opisu drużyny
        /// </summary>
        /// <returns>zwraca opis drużyny</returns>
        public string GetOpis() => opis;
        /// <summary>
        /// Pobieranie roku powstania drużyny
        /// </summary>
        /// <returns>zwraca rok powstania drużyny</returns>
        public int GetRokPowstania() => rokPowstania;
        /// <summary>
        /// Aktualizacja opisu drużyny
        /// </summary>
        /// <param name="nowyOpis">parametr określający nowy opis drużyny</param>
        public void AktualizujOpis(string nowyOpis)
        {
            opis = nowyOpis;
        }
        /// <summary>
        /// Pobieranie liczby punktów
        /// </summary>
        /// <returns>zwraca liczbę punktów drużyny</returns>
        public int GetPunkty() => punkty;
        /// <summary>
        /// Dodawanie punktów za zwycięstwo
        /// </summary>
        public void DodajZwycięztwo()
        {
            punkty += 2;
        }
        /// <summary>
        /// Dodawanie punktów za remis
        /// </summary>
        public void DodajRemis()
        {
            punkty += 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>zwraca "Drużyna"</returns>
        public override string ToString() => "Drużyna";
    }
}
