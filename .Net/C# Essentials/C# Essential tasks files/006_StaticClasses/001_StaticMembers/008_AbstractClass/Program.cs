using System;

// Статические члены в абстрактных классах.

namespace Static
{
    class Program
    {
        static void Main()
        {
            AbstractClass instance = AbstractClass.CreateObject();
            instance.Method();

            // Delay.
            Console.ReadKey();
        }
    }
}
