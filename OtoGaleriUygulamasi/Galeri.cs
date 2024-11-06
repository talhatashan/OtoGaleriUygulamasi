using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriUygulamasi
{
    internal class Galeri
    {
        // bu sınıf içerisinde galeri ile ilgili kodlar yazılacak
        // Galeriye ilişkin herhangi bir verinin değiştirilmesi gerektiğinde
        // ilgili kodlar bu sınıfta yazılmalı.

        public List<Araba> Arabalar = new List<Araba>();

        public int ToplamAracSayisi
        {
            get
            {
                return this.Arabalar.Count;
            }
        }
        
        public int KiradakiAracSayisi
        {
            get
            {
                int adet = 0;

                foreach (Araba item in Arabalar)
                    {
                   

                    if (item.Durum == "Kirada")
                        {
                            adet++;
                        }
                    }
                    return adet;
                

               
                
            }
        }
        int sureAdet;
        public int GaleridekiAracSayisi { get {
                return Arabalar.Count;
            } set { } }

        
        public int ToplamAracKiralamaSuresi
        {
            get
            {
                
                int toplam = 0;
                

                foreach (Araba item in Arabalar)
                {
                    
                    toplam += item.ToplamKiralanmaSuresi;
                    
                }

                return toplam;
            }
        }

        public int ToplamAracKiralamaAdeti { get
            {
                int toplam= 0;
                foreach(Araba item in Arabalar)
                {
                    toplam += item.KiralamaSureleri.Count;  
                }
                return toplam;
            }
            set { } }

        public float Ciro {
            get
            {
                float toplam = 0;


                foreach (Araba item in Arabalar)
                {
                    
                    toplam +=( item.ToplamKiralanmaSuresi * int.Parse(item.KiralamaBedeli));
                }

                return toplam;
            }
            set { } }


        public void ArabaKirala(string plaka, int sure)
        {
           

            Araba a = null;

            foreach (Araba item in Arabalar)
            {
                if (item.PLaka == plaka)
                {
                    a = item;
                }
            }

            if (a != null)
            {
                a.Durum = "Kirada";
                a.KiralamaSureleri.Add(sure);
            }

        }
        public void ArabaTeslimAl(string plaka)
        {
            // bu plakaya ait arabanın bulunması lazım.

            Araba a = null;

            foreach (Araba item in Arabalar)
            {
                if (item.PLaka == plaka)
                {
                    a = item;
                }
            }

            if (a != null)
            {
                a.Durum = "Galeride";

            }

        }

        public void KiralamaIptal(string plaka)
        {
            // arabayı bul

            // a.KiralamaSureleri.RemoveAt(KiralamaSureleri.Count - 1);
            // KiralamaSureleri ndeki en son elemanı listeden çıkarıyoruz
            
            bool arabaBulundu = false;
            foreach (Araba item in Arabalar)
            {
                if (item.KiralamaSureleri.Count == 0) { Console.WriteLine("Kirada araba yok."); break; }
                
                if (item.PLaka == plaka)
                {
                    arabaBulundu = true;
                    
                    if (item.Durum == "Kirada")
                    {
                        item.Durum = "Galeride";
                        Console.WriteLine("İptal gerçekleştirildi.");
                        Console.WriteLine();
                        if (item.KiralamaSureleri.Count > 0) {item.KiralamaSureleri.RemoveAt(item.KiralamaSureleri.Count-1); }
                        
                        break;
                    }
                    if (item.Durum == "Galeride") { Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride."); break; }
                    if (!arabaBulundu) { Console.WriteLine("Galeriye ait bu plakada bir araba yok."); }
                }
                
            }
        }
        
        public void ArabaEkle(string plaka, string marka, string kiralamaBedeli, string aTipi)
        {
            // parametreden aldığımız bu bilgiler ile yeni bir araba oluşacak.
            // bu oluşan arabayı Arabalar listesine de ekleyeceğiz.

            Araba a = new Araba(plaka, marka, kiralamaBedeli, aTipi);
            this.Arabalar.Add(a);
            
        }

        public void ArabaListele()
        {
            Console.WriteLine("-Tüm Arabalar-");
            Console.WriteLine();
            Console.WriteLine("Plaka         Marka       K. Bedeli   Araba Tipi  K. Sayısı   Durum");
            Console.WriteLine("----------------------------------------------------------------------");
            

            foreach (Araba item in Arabalar)
                {
                    Console.WriteLine(item.PLaka.ToUpper().PadRight(14) + item.Marka.ToUpper().PadRight(12)  + item.KiralamaBedeli.ToString().PadRight(12)  + item.AracTipi.ToString().PadRight(12) + item.KiralanmaSayisi.ToString().PadRight(12) +  item.Durum);
                }
            
            
        }
        public void KiraArabaListele()
        {
            Console.WriteLine("-Kiradaki Arabalar-");
            Console.WriteLine();
            bool kiradaMi = false;
       
            if (Arabalar.Count == 0 ) { Console.WriteLine("Listelenecek araç yok.");
                
            } else {
                
               
                
                foreach (Araba item in Arabalar)
                {

                    if (item.Durum == "Kirada")
                    {
                        kiradaMi = true;
                        Console.WriteLine("Plaka         Marka       K. Bedeli   Araba Tipi  K. Sayısı   Durum");
                        Console.WriteLine("----------------------------------------------------------------------");
                        Console.WriteLine(item.PLaka.ToUpper().PadRight(14) + item.Marka.ToUpper().PadRight(12) + item.KiralamaBedeli.ToString().PadRight(12) + item.AracTipi.ToString().PadRight(12) + item.KiralanmaSayisi.ToString().PadRight(12) + item.Durum);

                    }
                    if (!kiradaMi)
                    {
                        Console.WriteLine("Listelenecek araç yok.");
                        
                    }
                   
                }
            }
            

                


        }

        public void GaleriArabaListele()
        {
            Console.WriteLine("-Galerideki Arabalar-");
            Console.WriteLine();
            
            Console.WriteLine("Plaka         Marka       K. Bedeli   Araba Tipi  K. Sayısı   Durum");
            Console.WriteLine("----------------------------------------------------------------------");
            foreach (Araba item in Arabalar)
            {
                if (item.Durum == "Galeride")
                {

                    Console.WriteLine(item.PLaka.ToUpper().PadRight(14) + item.Marka.ToUpper().PadRight(12) + item.KiralamaBedeli.ToString().PadRight(12) + item.AracTipi.ToString().PadRight(12) + item.KiralanmaSayisi.ToString().PadRight(12) + item.Durum);

                }
            }


        }

        public void KiralamaIptali()
        {
            Console.WriteLine("-Kiralama İptali-");
            Console.WriteLine();
            
        }



        






    }
}
