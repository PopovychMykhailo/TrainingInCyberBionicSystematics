using System;

// Перегрузка операторов.

namespace Operators
{
    class Program
    {
        static void Main()
        {
            Point a = new Point(1, 1);
            Point b = new Point(2, 2);

            Console.WriteLine("Point.Add(a, b) = {0}", Point.Add(a, b));

            Console.WriteLine("Point.Subtract(a, b) = {0}", Point.Subtract(a, b));
            
            // Delay.
            Console.ReadKey();
        }
    }
}
