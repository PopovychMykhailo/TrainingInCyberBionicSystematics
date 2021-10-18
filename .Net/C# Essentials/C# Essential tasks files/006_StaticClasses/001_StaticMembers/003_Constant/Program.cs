using System;

// Константы.

namespace Static
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"e = {NotStaticClass.e}");

            // Delay.
            Console.ReadKey();
        }
    }
}
