using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TestRegExpr
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.Write("Введите шаблон     : "); // Например: \d 
                string pattern = Console.ReadLine();

                Console.Write("Введите выражение  : "); // Например: 123
                string text = Console.ReadLine();

                if (Regex.IsMatch(text, pattern))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("OK.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Beep();
                    Console.WriteLine("NO.");
                }

                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
