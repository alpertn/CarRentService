using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using CarRentService.MySql;
using System.Threading;
using CarRentService.Api;
using CarRentService.Services;
using System.Drawing.Printing;
using CarRentService.Services;

// Kodların buyuk bir kısmını notlar ile acıkladım.  goz gezdırmenızı onerırım.

namespace CarRentService
{
    class Program 
    {

        public static void Main()
        {
            Console.Title = "Sahibinden";
            DatabaseRun.DataRunner(); // Database başlatıcı. Insert ve Create gibi kodlar bu modülde calısacak. Tüm arabalar eklenecektir.

            bool donguanahtari = false;
            while (!donguanahtari) // false ise calısan while dongusu.
            {
                DatabaseRun.DataRunner();
                Console.Clear();

                Console.WriteLine("SahibindenElite Rent a Car Uygulamasına Hoş Geldiniz.\n");
                Console.Write("1 - Kayıt\n2 - Giriş\n3 - Admin Panel\n\nSeçim :  ");


                if (int.TryParse(Console.ReadLine(), out int intdeger) && intdeger >= 0 && intdeger <= 4)
                {
                    if (intdeger == 1)
                    {
                        donguanahtari = true;
                        int response = Register.Menu();

                        if (response != 0)
                        {

                            Console.Clear();

                            string CustomerName = Sorgu.CustomerIdAdSorgu(response);
                            if (CustomerName != null)
                            {
                                anamenu.menu(response, CustomerName);
                            }
                            else
                            {
                                Console.WriteLine("Bir Sorun Oluştu");
                            }




                        }
                    }
                    else if (intdeger == 2)
                    {
                        Console.Clear();
                        var loginmenu = Login.LoginMenu();
                        string id = Sorgu.CustomerIdSorgu(loginmenu.tc, loginmenu.password);
                        Console.WriteLine($"SahibindenElite Rent a Car Uygulamasına Hoş Geldin {loginmenu.response}.\n");
                        int newid = int.Parse(id);
                        anamenu.menu(newid, loginmenu.response); // ana menuye goturuyor.


                    }
                    else if (intdeger  == 3)
                    {
                        Console.WriteLine("Admin Paneline Hoş Geldin!");
                        Console.Write("\nAdmin Username :  ");
                        string adminusername = Console.ReadLine();
                        Console.Write("Admin Password :  ");
                        string adminpassword = Console.ReadLine();

                        if (Sorgu.checkadmin(adminusername,adminpassword) == true)
                        {
                            Console.WriteLine("Giriş Başarılı. Yönlendiriliyorsunuz");
                            Admin.AdminMenu();

                        }
                        else
                        {
                            Console.WriteLine("Giriş Başarısız");
                            Console.Read();

                        }

                    }
                    else
                    {
                        Console.WriteLine("Geçersiz giriş yaptınız. Program 3 saniye içinde yeniden başlayacaktır.");
                        Thread.Sleep(3000);
                        donguanahtari = false;
                    }


                }



            }
        }
    }
}
