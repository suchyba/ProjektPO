using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    /**
     * <summary>Klasa opisująca drużyny prowadzące rozgrywki.</summary>
     */
    class Druzyna
    {
        protected string nazwa;
        protected int rokPowstania;
        protected string opis;

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
    }
}
