using System;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;

namespace OtoGaleriUygulamasi
{
    internal class Program
    {
        // Kullanıcı ile etkileşime gireceğimiz bütün kodlar program sınıfı içerisinde yazılacak.

        static Galeri OtoGaleri = new Galeri();



        static void Main(string[] args)
        {
            OtoGaleri.ArabaEkle("34ARB3434", "FIAT", "70", "Sedan");
            OtoGaleri.ArabaEkle("35ARB3535", "KIA", "60", "SUV");
            OtoGaleri.ArabaEkle("34US2342", "OPEL", "50", "Hatchback");
            Uygulama();
        }



        static void Uygulama()
        {
            Menu();
            GeriAl();

            //while (true)
            //{
            //    string secim = SecimAl();

            //    switch (secim)
            //    {
            //        case "1":
            //        case "K":
            //            ArabaKirala();
            //            break;
            //        case "2":
            //        case "T":
            //            ArabaTeslimAl();
            //            break;
            //        case "3":
            //        case "R":
            //            KiraArabalariListele();
            //            break;
            //        case "4":
            //        case "M":
            //            GaleriArabalariListele();
            //            break;
            //        case "5":
            //        case "A":
            //            TumArabalariListele();
            //            break;
            //        case "6":
            //        case "I":
            //            KiralamaIptali();
            //            break;
            //        case "7":
            //        case "Y":
            //            ArabaEkle();
            //            break;
            //        case "8":
            //        case "S":
            //            ArabaSil();
            //            break;
            //        case "9":
            //        case "G":
            //            BilgileriGoster();
            //            break;
            //        case "X":
            //        Uygulama();
            //        break;




            //}
            //    Console.WriteLine();
            //}


        }
        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon                     ");
            Console.WriteLine("1- Araba Kirala(K)                  ");
            Console.WriteLine("2- Araba Teslim Al(T)               ");
            Console.WriteLine("3- Kiradaki Arabaları Listele(R)    ");
            Console.WriteLine("4- Galerideki Arabaları Listele(M)  ");
            Console.WriteLine("5- Tüm Arabaları Listele(A)         ");
            Console.WriteLine("6- Kiralama İptali(I)               ");
            Console.WriteLine("7- Araba Ekle(Y)                    ");
            Console.WriteLine("8- Araba Sil(S)                     ");
            Console.WriteLine("9- Bilgileri Göster(G)              ");
            

        }

        static string SecimAl()
        {
            string karakterler = "123456789KTRMAIYSGX";
            int sayac = 0;

            while (true)
            {
                sayac++;
                Console.WriteLine();
                Console.Write("Seçiminiz: ");

                string giris = Console.ReadLine().ToUpper();
                if (giris == "X" )
                {
                    return GeriAl();
                }
                int index = karakterler.IndexOf(giris);
                Console.WriteLine();

                if (giris.Length == 1 && index >= 0)
                {
                    return giris;
                }
                else { Console.WriteLine("Hatali giris yapildi."); }
                if (sayac == 10) { Environment.Exit(0); }
            }
        }

        static string ArabaKirala()
        {
            Console.WriteLine("-Araba Kirala-");
            Console.WriteLine();

            while (true)
            {

                string plaka = PlakaAl("Kiralanacak arabanın plakası: ");


                if (OtoGaleri.Arabalar.Count == 0)
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    continue;
                }


                bool arabaBulundu = false;
                bool kirada = false;



                foreach (Araba item in OtoGaleri.Arabalar)
                {
                    if (item.Durum == "Kirada")
                    {
                        Console.WriteLine("Araba şu anda kirada. Farklı araba seçiniz.");
                        arabaBulundu = true;
                        continue;
                    }

                    if (item.PLaka == plaka)

                    {
                        while (true)
                        {
                            arabaBulundu = true;
                            Console.Write("Kiralanma süresi: ");
                            string sure = Console.ReadLine();
                            int sayi;



                            bool sonuc = int.TryParse(sure, out sayi);
                            if (sonuc == true)
                            {
                                OtoGaleri.ArabaKirala(plaka, sayi);
                                Console.WriteLine(plaka.ToUpper() + " plakalı araba " + sure + " saatliğine kiralandı.");
                                kirada = true;

                                return GeriAl();

                            }
                            else if (sonuc == false)
                            {
                                if (sure.ToString() == "X" || sure.ToString() == "x") { return GeriAl(); }
                                else
                                {
                                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                                    continue;

                                }

                            }
                        }
                        




                    }



                }

                if (!arabaBulundu)
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    continue;
                }




            }








        }

        static string ArabaEkle()
        {

            Console.WriteLine("-Araba Ekle-");
            Console.WriteLine();
            bool arabaEklendi = false;
            while (true)
            {


                string plaka = PlakaAl("Plaka: ");

                bool plakaVar = false;
                foreach (Araba item in OtoGaleri.Arabalar)
                {


                    if (item.PLaka == plaka)
                    {
                        Console.WriteLine("Aynı plakada araba mevcut. Girdiğiniz plakayı kontrol edin.");
                        plakaVar = true;
                        break;
                    }

                }
                if (plakaVar)
                {
                    continue;
                }

                Console.Write("Marka: ");
                string marka = Console.ReadLine();
                if (marka == "X" || marka == "x") { return GeriAl(); }

                string kiralamaBedeli = SayiAl("Kiralama bedeli: ");
                Console.WriteLine("Araç tipi:");
                Console.WriteLine("SUV için 1");
                Console.WriteLine("Hatchback için 2");
                Console.WriteLine("Sedan için 3");
                while (true)
                {
                    Console.Write("Araç tipi: ");
                    string secim = Console.ReadLine();
                    if (secim =="X" || secim == "x") { return GeriAl(); }
                    string aTipi = "";
                    if (secim == "1" || secim == "2" || secim == "3")
                    {
                        switch (secim)
                        {
                            case "1":
                                aTipi = "SUV";
                                break;
                            case "2":
                                aTipi = "Hatchback";
                                break;
                            case "3":
                                aTipi = "Sedan";
                                break;
                            case "X":
                             case  "x":
                                    return GeriAl();

                        }

                        OtoGaleri.ArabaEkle(plaka, marka, kiralamaBedeli, aTipi);
                        Console.WriteLine();
                        arabaEklendi = true;
                        Console.WriteLine("Araba başarılı bir şekilde eklendi.");
                        return GeriAl();

                       
                    }
                    else { Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin."); }
                    
                    continue;
                }









            }

        }
        static void ArabaTeslimAl()

        {
            Console.WriteLine("-Araba Teslim Al-");
            Console.WriteLine();


            if (OtoGaleri.KiradakiAracSayisi == 0)
            {

                Console.WriteLine("Kirada hiç araba yok.");
            }
            else
            {
                string plaka = PlakaAl("Teslim edilecek arabanın plakası: ");
                Console.WriteLine();
                foreach (Araba item in OtoGaleri.Arabalar)
                {
                    if (item.PLaka == plaka)

                    {

                        Console.Write("Araba galeride beklemeye alındı. ");
                        Console.WriteLine();
                        item.Durum = "Galeride";

                    }


                }
            }
        }


        static string PlakaAl(string mesaj)

        {


            while (true)
            {
                Console.Write(mesaj);
                string plaka = Console.ReadLine();
                if (plaka == "X" || plaka=="x") { return GeriAl(); }




                char[] dizi = plaka.ToCharArray();




                if (dizi.Length <= 6 || dizi.Length > 10)
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    continue;
                }

                int sayi;
                int sayi1;

                if (!int.TryParse(dizi[0].ToString(), out sayi) || !int.TryParse(dizi[1].ToString(), out sayi1))
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    continue;
                }


                if (!char.IsLetter(dizi[2]))
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    continue;
                }


                if (dizi.Length > 3 && !char.IsLetterOrDigit(dizi[3]))
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    continue;
                }

                if (dizi.Length > 4 && !char.IsLetterOrDigit(dizi[4]))
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    continue;
                }


                int sonIndex = dizi.Length - 1;

                if (!char.IsDigit(dizi[sonIndex]) || !char.IsDigit(dizi[sonIndex - 1]))
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    continue;
                }


                if (dizi.Length >= 9 && !char.IsDigit(dizi[sonIndex - 2]))
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    continue;
                }


                return plaka;
            }
        }




        static string SayiAl(string mesaj)
        {
            int sayi;
            while (true)
            {
                Console.Write(mesaj);

                string giris = Console.ReadLine();

                if (int.TryParse(giris, out sayi))
                {
                    return sayi.ToString();
                }
                if (giris == "x" || giris == "X") { return GeriAl(); }
                else
                {
                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                }
                }
        }



        static void TumArabalariListele()
        {
            OtoGaleri.ArabaListele();
        }

        static void KiraArabalariListele()
        {

            OtoGaleri.KiraArabaListele();


        }

        static void GaleriArabalariListele()
        {
            OtoGaleri.GaleriArabaListele();
        }

        static void KiralamaIptali()
        {
            Console.WriteLine("-Kiralama İptali-");
            Console.WriteLine();

            bool kiradaArabaVar = false;

            foreach (Araba item in OtoGaleri.Arabalar)
            {
                if (item.KiralamaSureleri.Count > 0)
                {
                    kiradaArabaVar = true;

                    string plaka = PlakaAl("Kiralaması iptal edilecek arabanın plakası: ");
                    Console.WriteLine();

                    OtoGaleri.KiralamaIptal(plaka);
                    return;
                }
            }


            if (!kiradaArabaVar)
            {
                Console.WriteLine("Kirada araba yok.");
            }



        }

        static void ArabaSil()
        {
            Console.WriteLine("-Araba Sil-");
            Console.WriteLine();
            while (true)
            {
                string plaka = PlakaAl("Silmek istediğiniz arabanın plakasını giriniz: ");


                bool arabaBulundu = false;

                foreach (Araba item in OtoGaleri.Arabalar)
                {

                    if (item.PLaka == plaka)
                    {
                        arabaBulundu = true;

                        OtoGaleri.Arabalar.Remove(item);
                        Console.WriteLine("İptal gerçekleştirildi.");
                        return;

                    }

                }
                if (!arabaBulundu) { Console.WriteLine("Galeriye ait bu plakada bir araba yok."); continue; }

            }

        }

        static void BilgileriGoster()
        {

            Console.WriteLine("-Galeri Bilgileri-");

            Console.WriteLine("Toplam araba sayısı: " + OtoGaleri.Arabalar.Count);


            Console.WriteLine("Kiradaki araba sayısı: " + OtoGaleri.KiradakiAracSayisi);

            Console.WriteLine("Bekleyen araba sayısı: " + (OtoGaleri.ToplamAracSayisi - OtoGaleri.KiradakiAracSayisi));
            Console.WriteLine("Toplam araba kiralama süresi: " + OtoGaleri.ToplamAracKiralamaSuresi);
            Console.WriteLine("Toplam araba kiralama adedi: " + OtoGaleri.ToplamAracKiralamaAdeti);
            Console.WriteLine("Ciro: " + OtoGaleri.Ciro);


        }

        static string GeriAl()
        {
            while (true)
            {
                string secim = SecimAl();

                switch (secim)
                {
                    case "1":
                    case "K":
                        ArabaKirala();
                        break;
                    case "2":
                    case "T":
                        ArabaTeslimAl();
                        break;
                    case "3":
                    case "R":
                        KiraArabalariListele();
                        break;
                    case "4":
                    case "M":
                        GaleriArabalariListele();
                        break;
                    case "5":
                    case "A":
                        TumArabalariListele();
                        break;
                    case "6":
                    case "I":
                        KiralamaIptali();
                        break;
                    case "7":
                    case "Y":
                        ArabaEkle();
                        break;
                    case "8":
                    case "S":
                        ArabaSil();
                        break;
                    case "9":
                    case "G":
                        BilgileriGoster();
                        break;
                    case "X":
                        Uygulama();
                        break;




                }
            }

        }

        public void AddCarAuto()
        {
            ArabaEkle();
        }


    }
}

                       
                    
                
            
         

