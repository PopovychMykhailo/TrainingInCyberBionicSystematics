using System;

// Базовый класс Object.

namespace ClassObject
{
    class Program
    {
        static void Main()
        {
            Object obj = new Object();

            Type type = obj.GetType();

            Console.WriteLine(type.ToString());
            
            // Delay.
            Console.ReadKey();
        }
    }
}
