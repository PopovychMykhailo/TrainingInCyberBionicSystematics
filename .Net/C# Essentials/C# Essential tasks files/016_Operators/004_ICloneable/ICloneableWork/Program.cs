using System;

namespace ICloneableWork
{
    class Program
    {
        static void Main()
        {
            Point original = new Point(100, 100);
            Point clone = original.Clone() as Point;

            Console.WriteLine("After cloning");

            Console.WriteLine(original);
            Console.WriteLine(clone);

            clone.x = 0;

            Console.WriteLine("After modification of the clone");
            Console.WriteLine(original);
            Console.WriteLine(clone);

            // Delay.
            Console.ReadKey();
        }
    }
}
