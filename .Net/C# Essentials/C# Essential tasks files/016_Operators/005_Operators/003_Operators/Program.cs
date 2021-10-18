using System;

// Перегрузка операторов. (Унарные операторы ++/--)

namespace Operators
{
    class Program
    {
        static void Main()
        {
            Point a = new Point(0, 0);

            Console.WriteLine("a   = {0}", a);
            Console.WriteLine("a++ = {0}", a++);
            Console.WriteLine("a   = {0}", a);

            Console.WriteLine("a-- = {0}", a--);
            Console.WriteLine("a   = {0}", a);

            Console.WriteLine("++a = {0}", ++a);
            Console.WriteLine("a   = {0}", a);

            Console.WriteLine("--a = {0}", --a);
            Console.WriteLine("a   = {0}", a);

            // Delay.
            Console.ReadKey();
        }
    }
}
