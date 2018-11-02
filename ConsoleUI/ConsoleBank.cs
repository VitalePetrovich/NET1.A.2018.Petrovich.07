using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NET1.A._2018.Petrovich._07;

namespace NET1.S._2018.Petrovich._07.ConsoleUI
{
    class ConsoleBank
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("us-US");
            
            bool exit = false;
          
            BankService bs = new BankService(new FakeRepository());

            string input;
            
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Enter command:");
                input = Console.ReadLine();

                string[] keywords = input.Split(' ');

                switch (keywords[0].ToUpperInvariant())
                {
                    case "NEWACC":
                        try
                        {
                            bs.NewAccount(keywords[1], keywords[2], new PlatinumAccountFactory());
                            Console.WriteLine("Successful!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    //case "STATUS":
                    //    try
                    //    {
                    //        foreach (var abstractAccount in ((FakeRepository)bs.repository).dictionaryRepository.Values)
                    //        {
                    //            Console.WriteLine(abstractAccount.ToString("s"));
                    //        }
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        Console.WriteLine(e.Message);
                    //    }
                    //    break;

                    case "DEPOSIT":
                        try
                        {
                            bs.Deposit(keywords[1], decimal.Parse(keywords[2]));
                            Console.WriteLine("Successful!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "WITHDRAW":
                        try
                        {
                            bs.Withdraw(keywords[1], decimal.Parse(keywords[2]));
                            Console.WriteLine("Successful!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "CLOSE":
                        try
                        {
                            bs.CloseAccount(keywords[1]);
                            Console.WriteLine("Successful!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "EXIT":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine($"Incorrect command '{keywords[0]}'!");
                        break;
                }

                Console.ReadKey();
            }
        }
    }
}
