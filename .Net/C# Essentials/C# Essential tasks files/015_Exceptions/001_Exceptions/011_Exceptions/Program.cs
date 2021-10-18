using System;

// Обработка исключений.

// finally - срабатывает в случае возникновения исключения OutOfMemoryException.

namespace Exceptions
{
    class Program
    {
        public static void Method()
        {
            int[] arr = new int[100000000];
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
                // finally - сработает.
                Console.WriteLine("Finally");
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
