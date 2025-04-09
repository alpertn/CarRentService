using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentService.MySql;

namespace CarRentService.Services
{
    public class anamenu
    {
        public static void menu(int response, string CustomerName)
        {
            bool donusanahtari = true;
            while (!donusanahtari)
            {
                Console.Clear();
                Console.WriteLine($"SahibindenElite Rent a Car Uygulamasına Hoş Geldin {CustomerName}.\n");
                Console.Write("1 - Araba Kirala\n2 - Kullanıcı Sözleşmesi\n3 - Akaryakıt Fiyatları(eklenecek)\n4 - Sikayet / Oneri Geri Bildirimi\n5 - Cikis\n\nSecim :  ");

                if (int.TryParse(Console.ReadLine(), out int secim) && secim >= 0 && secim <= 5)
                {
                    if (secim == 1)
                    {
                        Console.Clear();
                        string carbrandresponse = Car.Brand();

                        if (carbrandresponse != "hata")
                        {
                            Console.Clear();
                            Console.WriteLine($"Sayın {CustomerName} Seçtiğiniz Arabanın Bilgileri : ");
                            Sorgu.CarIdSorgu(carbrandresponse);

                            Console.WriteLine("\nKiralamak istediğiniz paketi seciniz. Gün olarak kiralamak istiyorsanız kaç gün kiralamak istediğinizi yazınız. Örnek : ('4' / 'Günlük' / 'Haftalık' / 'Aylık')\nSecim :  ");
                            string input = Console.ReadLine();
                            string response1 = response.ToString();
                            if (input.ToLower() == "günlük")
                            {
                                RentCar.Rent(carbrandresponse, response1, 1);
                                Console.WriteLine("Araba Kiralandı.");
                            }
                            else if (input.ToLower() == "haftalık")
                            {
                                RentCar.Rent(carbrandresponse, response1, 7);
                                Console.WriteLine("Araba Kiralandı.");

                            }
                            else if (input.ToLower() == "aylık")
                            {
                                RentCar.Rent(carbrandresponse, response1, 30);
                                Console.WriteLine("Araba Kiralandı.");

                            }
                            else if (int.TryParse(input, out int intinput))
                            {
                                if (intinput != 0 && intinput >= 0) // & ve demektir.
                                {
                                    RentCar.Rent(carbrandresponse, response1, intinput);
                                    Console.WriteLine("Araba Kiralandı.");
                                    Console.Read();

                                }
                                else
                                {
                                    Console.WriteLine("bir sorun oluştu.");
                                }
                            }
                        }

                    }
                    else if (secim == 2)
                    {
                        kullanicisozlesmesi.kullanicisoz();
                        Console.ReadLine();
                        donusanahtari = false;
                    }else if (secim == 3)
                    {
                        Console.WriteLine("eklenecek...");
                        Console.Read();
                        donusanahtari = false;
                    }
                    else if (secim == 5)
                    {
                        Environment.Exit(0);
                    }
                }

            }
        }
    }
}
