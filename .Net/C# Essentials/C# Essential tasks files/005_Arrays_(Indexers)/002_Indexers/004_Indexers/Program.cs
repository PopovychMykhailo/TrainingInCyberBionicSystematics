using System;

// Индексаторы.

namespace Indexers
{
    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();

            my[1, 1] = 2;

            Console.WriteLine(my[1, 1]);
            Console.WriteLine(my[0, 0]);

            // Delay.
            Console.ReadKey();
        }
    }
}
