using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    enum Sporty
    {
        Siatkowka, PrzeciaganieLiny, DwaOgnie
    }
    /**
     * <summary>Klasa opisująca drużyny prowadzące rozgrywki.</summary>
     */
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



        /**
         * <summary>Konstruktor przyjmujacy podstawowe dane o drużynie.</summary>
         */
        public Druzyna(string n, int r, string o)
        {
            nazwa = n;
            rokPowstania = r;
            opis = o;
        }

        public string GetNazwa() => nazwa;
        public string GetOpis() => opis;
        public int GetRokPowstania() => rokPowstania;
        public void AktualizujOpis(string nowyOpis)
        {
            opis = nowyOpis;
        }
        public int GetPunkty() => punkty;
        public void DodajZwycięztwo()
        {
            punkty += 2;
        }
        public void DodajRemis()
        {
            punkty += 1;
        }
        public override string ToString()
        {
            return "Drużyna: " + nazwa;
        }
    }
}
