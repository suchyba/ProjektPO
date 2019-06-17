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
    /// 
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
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <param name="o"></param>
        public Druzyna(string n, int r, string o)
        {
            nazwa = n;
            rokPowstania = r;
            opis = o;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetNazwa() => nazwa;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetOpis() => opis;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetRokPowstania() => rokPowstania;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nowyOpis"></param>
        public void AktualizujOpis(string nowyOpis)
        {
            opis = nowyOpis;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetPunkty() => punkty;
        /// <summary>
        /// 
        /// </summary>
        public void DodajZwycięztwo()
        {
            punkty += 2;
        }
        /// <summary>
        /// 
        /// </summary>
        public void DodajRemis()
        {
            punkty += 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Drużyna";
        }
    }
}
