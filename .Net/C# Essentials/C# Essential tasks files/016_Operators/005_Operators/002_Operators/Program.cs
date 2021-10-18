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

            Console.WriteLine("a + b = {0}", a + b);
            Console.WriteLine("a - b = {0}", a - b);
            Console.WriteLine("a * b = {0}", a * b);
            Console.WriteLine("a / b = {0}", a / b);

            Point c = new Point(0, 0);
            c += a;
            Console.WriteLine("c = {0}", c);

            // Delay.
            Console.ReadKey();
        }
    }
}
