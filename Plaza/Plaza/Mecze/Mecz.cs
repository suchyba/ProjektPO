using System;
using System.Runtime.Serialization;

namespace Plaza
{
    enum StopienMeczu { MeczLigowy = 0, MeczPolfinalowy = 1, MeczFinalowy = 2 };
    /// <summary>
    /// Klasa opisująca mecze
    /// </summary>
    class Mecz : ISerializable
    {
        /// <summary>
        /// pola potrzebne do określenia meczu
        /// </summary>
        protected Druzyna[] druzyny;
        protected Sedzia sedziaGlowny;
        protected int[] wynik;
        protected int stopienMeczu;

        /// <summary>
        /// Pobieranie drużyny pierwszej dla meczu
        /// </summary>
        public Druzyna DruzynaPierwsza { get => druzyny[0]; }
        /// <summary>
        /// Pobieranie drużyny drugiej dla meczu
        /// </summary>
        public Druzyna DruzynaDruga { get => druzyny[1]; }
        /// <summary>
        /// Pobieranie sędziego głównego dla meczu
        /// </summary>
        public Sedzia SedziaGlowny { get => sedziaGlowny; }
        /// <summary>
        /// Pobieranie wyniku meczu 
        /// </summary>
        public string WynikString { get => wynik[0] != -1 ? wynik[0] + " : " + wynik[1] : "Nierozegrany"; }
        /// <summary>
        /// Określanie stopnia meczu
        /// </summary>
        public string StopienMeczuString
        {
            get
            {
                switch (stopienMeczu)
                {
                    case 0:
                        {
                            return "Mecz Ligowy";
                        }
                    case 1:
                        {
                            return "Mecz Półfinałowy";
                        }
                    case 2:
                        {
                            return "Mecz Finałowy";
                        }
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// Budowa meczu
        /// </summary>
        /// <param name="d1">parametr określający drużynę pierwszą</param>
        /// <param name="d2">parametr określający drużynę drugą</param>
        /// <param name="sd">parametr określający sędziego głównego</param>
        /// <param name="stM">parametr określający stopień meczu</param>
        public Mecz(Druzyna d1, Druzyna d2, Sedzia sd, int stM)
        {
            druzyny = new Druzyna[2];
            druzyny[0] = d1;
            druzyny[1] = d2;
            sedziaGlowny = sd;
            stopienMeczu = stM;
            wynik = new int[2];
            wynik[0] = -1;
            sd.ZwiekszIloscMeczow();
        }
        /// <summary>
        /// Wyznaczanie wyników
        /// </summary>
        /// <param name="d1">parametr określający drużynę pierwszą</param>
        /// <param name="d2">parametr określający drużynę drugą</param>
        /// <param name="sd">parametr określający sędziego głównego</param>
        /// <param name="stM">parametr określający stopień meczu</param>
        /// <param name="w1">parametr określający wynik drużyny pierwszej</param>
        /// <param name="w2">parametr określający wynik drużyny drugiej</param>
        public Mecz(Druzyna d1, Druzyna d2, Sedzia sd, int stM, int w1, int w2) : this(d1, d2, sd, stM)
        {
            wynik[0] = w1;
            wynik[1] = w2;
            if (stM == (int)StopienMeczu.MeczLigowy)
            {
                if (w1 > w2)
                    d1.DodajZwycięztwo();
                else if (w2 > w1)
                    d2.DodajZwycięztwo();
                else if (w1 == w2)
                {
                    d1.DodajRemis();
                    d2.DodajRemis();
                }
            }
        }

        public Mecz(SerializationInfo info, StreamingContext context)
        {
            
        }

        /// <summary>
        /// Pobieranie drużyn
        /// </summary>
        /// <returns>zwraca drużyny</returns>
        public Druzyna[] GetDruzyny() => druzyny;
        /// <summary>
        /// Pobieranie wyniku meczu
        /// </summary>
        /// <returns>zwraca wynik meczu</returns>
        public int[] GetWynik() => wynik;
        /// <summary>
        /// Ustawianie wyników
        /// </summary>
        /// <param name="w1">parametr określający wynik pierwszy</param>
        /// <param name="w2">parametr określający wynik drugi</param>
        public void UstawWyniki(int w1, int w2)
        {
            wynik[0] = w1;
            wynik[1] = w2;
            if (stopienMeczu == (int)StopienMeczu.MeczLigowy)
            {
                if (w1 > w2)
                    druzyny[0].DodajZwycięztwo();
                else if (w2 > w1)
                    druzyny[1].DodajZwycięztwo();
                else if (w1 == w2)
                {
                    druzyny[0].DodajRemis();
                    druzyny[1].DodajRemis();
                }
            }
        }
        /// <summary>
        /// Pobieranie stopnia meczu
        /// </summary>
        /// <returns>zwraca stopień rozgrywanego meczu</returns>
        public int GetStopienMeczu() => stopienMeczu;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Druzyna1", druzyny[0]);
            info.AddValue("Druzyna2", druzyny[1]);
            info.AddValue("SedziaGlowny", sedziaGlowny);
            info.AddValue("Wynik1", wynik[0]);
            info.AddValue("Wynik2", wynik[1]);
            info.AddValue("Stopien", stopienMeczu);
        }
    }
}
