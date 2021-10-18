using System;

// Базовый класс Object.

namespace ClassObject
{   
    class Program 
    {
        static void Main()
        {
            Object obj1 = new Object();
            Object obj2 = new Object();

            Console.WriteLine(obj1.Equals(obj2));

            obj1 = obj2;

            Console.WriteLine(obj1.Equals(obj2)); 

            // Delay.
            Console.ReadKey();
        }
    }
}
