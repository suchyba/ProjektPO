﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plaza
{
    enum StopienMeczu { MeczLigowy = 0, MeczPolfinalowy = 1, MeczFilalowy = 2};
    class Mecz
    {
        protected Druzyna[] druzyny;
        protected Sedzia sedziaGlowny;
        protected int[] wynik;
        protected int stopienMeczu;

        public Mecz(Druzyna d1, Druzyna d2, Sedzia sd, int stM)
        {
            druzyny = new Druzyna[2];
            druzyny[0] = d1;
            druzyny[1] = d2;
            sedziaGlowny = sd;
            stopienMeczu = stM;
            wynik = new int[2];
        }
        public Mecz(Druzyna d1, Druzyna d2, Sedzia sd, int stM, int w1, int w2) : this(d1, d2, sd, stM)
        {
            wynik[0] = w1;
            wynik[1] = w2;
            if(stM == (int)StopienMeczu.MeczLigowy)
            {
                if (w1 > w2)
                    d1.DodajZwycięztwo();
                else if (w2 > w1)
                    d2.DodajZwycięztwo();
                else if(w1 == w2)
                {
                    d1.DodajRemis();
                    d2.DodajRemis();
                }
            }
        }
        public Druzyna[] GetDruzyny() => druzyny;
        public Sedzia GetSedziaGlowny() => sedziaGlowny;
        public int[] GetWynik() => wynik;
        public void UstawWyniki(int w1, int w2)
        {
            wynik[0] = w1;
            wynik[1] = w2;
        }
        public int GetStopienMeczu() => stopienMeczu;
    }
}
