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
            Exception ex = new Exception("Мое Исключение");

            try
            {
                throw ex;
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
