using System;
using System.Text;

// Обработка исключений.

// finally - не срабатывает в случае возникновения исключения StackOverflowException.

namespace Exceptions
{
    class Program
    {
        public static void Method()
        {
            int[] arr = new int[10];
            Console.WriteLine(arr);
            Method();
        }

        static void Main()
        {
            try
            {
                Method();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // finally - не сработает.
                while (true)
                    Console.WriteLine("Finally");
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
