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
        protected List<string> listaZawodnikow;
        protected int rokPowstania;
        protected string opis;

        /**
         * <summary>Konstruktor przyjmujacy podstawowe dane o drużynie.</summary>
         */
        public Druzyna(string n, int r, string o)
        {
            listaZawodnikow = new List<string>();
            nazwa = n;
            rokPowstania = r;
            opis = o;
        }
        public Druzyna(string n, int r, string o, string[] zawodnicy) : this(n, r, o)
        {            
            foreach (string zawodnik in zawodnicy)
            {
                listaZawodnikow.Add(zawodnik);
            }
        }

        public string GetNazwa() => nazwa;
        public string GetOpis() => opis;
        public int GetRokPowstania() => rokPowstania;
        public List<string> GetListaZawodnikow() => listaZawodnikow;
        public void AktualizujOpis(string nowyOpis)
        {
            opis = nowyOpis;
        }
    }
}
