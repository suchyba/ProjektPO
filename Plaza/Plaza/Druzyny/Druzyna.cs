using System.Runtime.Serialization;

namespace Plaza
{
    enum Sporty
    {
        Siatkowka = 0, PrzeciaganieLiny = 1, DwaOgnie = 2
    }
    /// <summary>
    /// Klasa określająca drużyny
    /// </summary>
    class Druzyna : ISerializable
    {
        /// <summary>
        /// Cmienne wykorzystywane przy drużynie
        /// </summary>
        protected string nazwa;
        protected int rokPowstania;
        protected string opis;
        protected int punkty;

        /// <summary>
        /// Konstruktor nazwy drużyny
        /// </summary>
        public string Nazwa { get => nazwa; set { nazwa = value; } }
        /// <summary>
        /// zwracanie roku powstania drużyny
        /// </summary>
        public int RokPowstania => rokPowstania;
        /// <summary>
        /// zwracanie opisu drużyny
        /// </summary>
        public string Opis => opis;
        /// <summary>
        /// zwracanie punktów drużyny
        /// </summary>
        public int Punkty => punkty;
        /// <summary>
        /// zwracanie "Drużyna"
        /// </summary>
        public virtual string Sport => "Drużyna";



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

        public Druzyna(SerializationInfo info, StreamingContext context)
        {
            nazwa = info.GetString("Nazwa");
            rokPowstania = info.GetInt32("RokPowstania");
            opis = info.GetString("Opis");
            punkty = info.GetInt32("Punkty");
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Nazwa", this.nazwa);
            info.AddValue("Opis", this.opis);
            info.AddValue("Punkty", this.punkty);
            info.AddValue("RokPowstania", rokPowstania);
        }
    }
}
