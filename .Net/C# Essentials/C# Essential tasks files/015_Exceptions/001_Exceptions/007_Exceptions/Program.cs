using System;
using System.Text;

// Обработка исключений.

namespace Exceptions
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            int a = 1, n = 2;

            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Попытка деления на ноль.");               
                Console.WriteLine("a / (2 - n) = {0}", a / (2 - n));
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Обработка исключения.");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            
            Console.WriteLine("Press any key...");

            // Delay.
            Console.ReadKey();
        }
    }
}
