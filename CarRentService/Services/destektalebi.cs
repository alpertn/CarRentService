using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CarRentService.MySql;

namespace CarRentService.Services
{
    public class destektalebi
    {
        public static void destek()
        {
            Console.Clear();

            Console.WriteLine("Destek Talebi Sayfamıza Hoş Geldiniz.\n");
            Console.Write("Lütfen destek talebinizin başlığını yazınız (Açıklama sonra sorulacaktır).\nSecim :  ");
            string baslik = Console.ReadLine();
            Console.Write("Talebinizin açıklamasını yazınız.\nSecim :  ");
            string aciklama = Console.ReadLine();
            Update.destektalebi(baslik, aciklama);
            Console.WriteLine("Destek Talebiniz Gönderilmiştir.");
            Console.WriteLine("Programdan Cikmak Icin Herhangi Bir Tusa Basiniz.");
            Console.ReadKey();
            Environment.Exit(1);

        }
    }
}
