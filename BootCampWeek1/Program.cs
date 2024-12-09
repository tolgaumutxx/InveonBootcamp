using System;
using BootCampWeek1.SRP_Example;
using BootCampWeek1.OCP_Example;
using BootCampWeek1.LSP_Example;
using BootCampWeek1.ISP_Example;
using BootCampWeek1.DIP_Example;
using BootCampWeek1.Async_Example;

namespace BootCampWeek1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose Example to Run:");
            Console.WriteLine("1 - SRP Example");
            Console.WriteLine("2 - OCP Example");
            Console.WriteLine("3 - LSP Example");
            Console.WriteLine("4 - ISP Example");
            Console.WriteLine("5 - DIP Example");
            Console.WriteLine("6 - Async Example");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SRPProgram.Main(args);
                    break;
                case "2":
                    OCPProgram.Main(args);
                    break;
                case "3":
                    LSPProgram.Main(args);
                    break;
                case "4":
                    ISPProgram.Main(args);
                    break;
                case "5":
                    DIPProgram.Main(args);
                    break;
                
                case "6":
                    AsyncProgram.Main(args);
                    break;
                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }
}
