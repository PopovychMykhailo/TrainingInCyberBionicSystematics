using System;

// Статические члены в нестатических классах.

namespace Static
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(NotStaticClass.Property);
            
            // Delay.
            Console.ReadKey();
        }
    }
}
