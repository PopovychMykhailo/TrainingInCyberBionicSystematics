using System;

// Динамические типы данных. (Локальные переменные)

namespace Dynamic
{
    class Program
    {
        static void Main()
        {
            dynamic variable = 1;

            Console.WriteLine(variable);

            variable = "Hello world!";

            Console.WriteLine(variable);

            variable = DateTime.Now;

            Console.WriteLine(variable);

            // Delay.
            Console.ReadKey();
        }
    }
}
