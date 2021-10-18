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
            try
            {
                throw new Exception("Мое Исключение");
            }
            catch (Exception e)
            {
                Console.WriteLine("Обработка исключения.");
                Console.WriteLine(e.Message);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
