using System;

// Обработка исключений.

// finally - не срабатывает если не завершается работа блока catch.

namespace Exceptions
{
    class Program
    {
        static void Main()
        {
            try
            {
                throw new Exception();
            }
            catch (Exception)
            {
                //throw new Exception();

                // или так ...

                while (true)
                    Console.WriteLine("Catch");
            }
            finally
            {
                // finally - не сработает!
                while (true)
                    Console.WriteLine("Finally");
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
