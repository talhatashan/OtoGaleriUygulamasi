using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriUygulamasi
{
    internal class Araba
    {
        // Bu sınıfta araba ile ilgili özellik ve işlemler olmalı.

        public string PLaka { get; set; }
        public string Marka { get; set; }
        public string KiralamaBedeli { get; set; }
        public string AracTipi { get; set; }
        public string Durum { get; set; }

        public List<int> KiralamaSureleri = new List<int>();
        

        public Araba(string plaka, string marka, string kiralamaBedeli, string aracTipi) 
        {
            this.PLaka = plaka;
            this.Marka = marka;
            this.KiralamaBedeli = kiralamaBedeli;
            this.AracTipi = aracTipi;
            this.Durum = "Galeride";
        }


        public int KiralanmaSayisi
        {
            get
            {
                return this.KiralamaSureleri.Count;
            }
        }

        public int ToplamKiralanmaSuresi
        {
            get
            {
                //int toplam = 0;

                //foreach (int item in KiralamaSureleri)
                //{
                //    toplam += item;
                //}
                //return toplam;

                return this.KiralamaSureleri.Sum();

            }
        }

    }
}
