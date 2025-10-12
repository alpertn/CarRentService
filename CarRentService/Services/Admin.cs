using CarRentService.MySql;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Pqc.Crypto.Utilities;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentService.Services
{
    public class Admin
    {
        private static string connectionString = "Server=localhost;Database=CarRent;User=root;Password=122333;";
        public static void AdminMenu()
        {
            Console.Clear();
            Console.Write("Admin Paneline Hoş Geldiniz.\n\n1 - Müşteri Hizmetleri Paneli\n2 - Kiralanan Arabalar Paneli\n3 - Sikayet Oneri/Destek Paneli\nSecim :  ");
            string secim = Console.ReadLine();
            if (secim == "1")
            {

                CustomerAdmin();

            }
            else if (secim == "2")
            {

                CheckRent();

            }
            else if (secim == "3")
            {



            }
            else
            {
                Console.WriteLine("Yanlış Secim");
            }

        }
        public static void CheckRent()
        {
            var tosql = $@"SELECT * FROM rent";

            MySqlConnection connect = new MySqlConnection(connectionString);

            connect.Open();

            var table = new Table() //güzel gozukmesı ıcın tabloe ekledım.
                .AddColumn("[yellow]Id[/]")
                .AddColumn("[yellow]CustomerId[/]")
                .AddColumn("[yellow]CarId[/]")
                .AddColumn("[yellow]RentDate[/]")
                .AddColumn("[yellow]ReturnDate[/]");



            using (MySqlCommand cmd = new MySqlCommand(tosql, connect))
            using (MySqlDataReader read = cmd.ExecuteReader())
            {
                while (read.Read())
                {

                    string Id = read["id"].ToString();
                    string CustomerId = read["CustomerId"].ToString();
                    string CarId = read["CarId"].ToString();
                    string RentDate = read["RentDate"].ToString();
                    string ReturnDate = read["ReturnDate"].ToString();

                    table.AddRow($"[bold white]{Id}[/]", $"[bold white]{CustomerId}[/]", $"[bold white]{CarId}[/]", $"[deepskyblue1]{RentDate}[/]", $"[bold green]{ReturnDate}[/]");
                    Console.ReadLine();


                }

            }
            AnsiConsole.Write(table);
            Console.Read();
        }


        public static void CustomerAdmin()
        {
            Console.Write("Customer Admin Paneline Hoş Geldiniz.\n\n1 - Kullanıcı Ekle/Sil\n2 - Kullanıcı Id Sorgu\n3 - Kullanıcıları Göster\n4 - ");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Console.Clear();
                Console.Write("Kullanıcı Ekleme/Silme Ekranına Hoş Geldiniz.\n\n1 - Kullanıcı Ekle\n2 - Kullanıcı Sil\n3 - Kullanıcı Listesi\nSecim :  ");
                 secim = Console.ReadLine();

                if (secim == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Kullanıcı Ekleme Ekranına Hoşgeldiniz.\n\n");

                    Console.Write("CustomerName: ");
                    string CustomerName = Console.ReadLine();

                    Console.Write("CustomerSurname: ");
                    string CustomerSurname = Console.ReadLine();

                    Console.Write("CustomerPhone: ");
                    string CustomerPhone = Console.ReadLine();

                    Console.Write("CustomerTc: ");
                    string CustomerTc = Console.ReadLine();

                    Console.Write("CustomerBirthYear: ");
                    string CustomerBirthYear = Console.ReadLine();

                    Console.Write("CustomerPassword: ");
                    string CustomerPassword = Console.ReadLine();

                    Update.AddUser(CustomerName, CustomerSurname, CustomerPhone,CustomerTc,CustomerBirthYear,CustomerPassword);
                    Console.WriteLine("User Eklendi!");
                    Console.ReadLine();
                }
                else if (secim == "2") {

                    Console.Write("Silmek istediğiniz kullanıcı'nın id'sini giriniz.\nSecim :  ");
                    string id = Console.ReadLine();

                    customersil(id);
                    Console.WriteLine("Customer Silindi");

                }
                else if (secim == "3")
                {
                    customerall();
                }
                else
                {
                    Console.WriteLine("hata");
                }

            }
            if (secim == "2")
            {
                customersorgu.customersorgumenu();

            }
            if (secim == "3")
            {

                  customerall();



            }
            else
            {
                Console.WriteLine("hata");
            }


        }   

        public static void customersil(string id)
        {
            var tosql = @$"DELETE FROM Customer WHERE Id = {id}";

            MySqlConnection mysqlconnection = new MySqlConnection(connectionString);
            mysqlconnection.Open();

            using (MySqlCommand command = new MySqlCommand(tosql , mysqlconnection))
            {
                command.ExecuteNonQuery();
                
            }
        }


        public static void customerall()
        {
            var tosql = @$"select * from customer";

            MySqlConnection connect = new MySqlConnection(connectionString);

            connect.Open();

            var table = new Table()
            .AddColumn("[yellow]Id[/]")
            .AddColumn("[yellow]CustomerName[/]")
            .AddColumn("[yellow]CustomerSurname[/]")
            .AddColumn("[yellow]CustomerPassword[/]")
            .AddColumn("[yellow]CustomerPhone[/]")
            .AddColumn("[yellow]CustomerTc[/]")
            .AddColumn("[yellow]CustomerBirthYear[/]");
            using (MySqlCommand cmd = new MySqlCommand(tosql, connect))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {

                    table.AddRow(
                        $"[yellow]{reader["Id"].ToString()}[/]",
                        $"[white]{reader["CustomerName"].ToString()}[/]",
                        $"[white]{reader["CustomerSurname"].ToString()}[/]",
                        $"[white]{reader["CustomerPassword"].ToString()}[/]",
                        $"[white]{reader["CustomerPhone"].ToString()}[/]",
                        $"[white]{reader["CustomerTc"].ToString()}[/]",
                        $"[white]{reader["CustomerBirthYear"].ToString()}[/]");


                }
                AnsiConsole.Write(table);


            }
        }



    }
    class customersorgu
    {
        public static void customersorgumenu()
        {
            Console.Write("Sorgulamak İstediğiniz Customer'in Id'sini giriniz\nSecim :  ");
            string id = Console.ReadLine();

            List<string> customer = Sorgu.CustomerIdFullSorgu(id);

            var table = new Table()
            .AddColumn("[yellow]Id[/]")
            .AddColumn("[yellow]CustomerName[/]")
            .AddColumn("[yellow]CustomerSurname[/]")
            .AddColumn("[yellow]CustomerPassword[/]")
            .AddColumn("[yellow]CustomerPhone[/]")
            .AddColumn("[yellow]CustomerTc[/]")
            .AddColumn("[yellow]CustomerBirthYear[/]");

            table.AddRow(
                $"[yellow]{customer[0]}[/]",
                $"[white]{customer[1]}[/]",
                $"[white]{customer[2]}[/]",
                $"[white]{customer[3]}[/]",
                $"[white]{customer[4]}[/]",
                $"[white]{customer[5]}[/]",
                $"[white]{customer[6]}[/]");
            AnsiConsole.Write(table);
            Console.ReadLine();
        }
    }
        
    
}
