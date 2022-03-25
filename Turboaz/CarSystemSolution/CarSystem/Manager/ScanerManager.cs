using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Infrastructure;

namespace CarSystem.Manager
{
    internal class ScanerManager
    {
        public static void PrintError(string message)
        {
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ResetColor();
        }
        public static int ReadInteger(string caption)
        {
        l1:
            Console.WriteLine(caption);
            Console.ForegroundColor = ConsoleColor.Green;
           

            if (!int.TryParse(Console.ReadLine(), out int value))
            {

                PrintError("Duzgun melumat deyil yeniden cehd edin");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }
        public static string ReadString(string caption)
        {
        l1:
            Console.WriteLine(caption);
            Console.ForegroundColor = ConsoleColor.Green;
            string value = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(value))
            {

                PrintError("Duzgun melumat deyil yeniden cehd edin");
                goto l1;
            }

            Console.ResetColor();
            return value;
        }
        public static double ReadDouble(string caption)
        {
        l1:
            Console.WriteLine(caption);
            Console.ForegroundColor = ConsoleColor.Green;

            if (!double.TryParse(Console.ReadLine(), out double value))
            {

                PrintError("Duzgun melumat deyil yeniden cehd edin");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }
        public static Menu ReadMenu(string caption)
        {
        l1:
            Console.WriteLine(caption);
            Console.ForegroundColor = ConsoleColor.Green;

            if (!Enum.TryParse(Console.ReadLine(), out Menu menu))
            {

                PrintError("Düzgün seçim edin!");
                goto l1;
            }
            Console.ResetColor();
            return menu;
        }
    }
}
