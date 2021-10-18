using System;
using System.Text;

namespace StringFormat
{
    class Program
    {
        static void Main()
        {

            int a = 1;

            Console.WriteLine("Это число " + a);

            Console.WriteLine("Это число {0}", a);

            // Интерполяция строк
            Console.WriteLine($"Это число {a}");

            int b = 2, c = 3;
            Console.WriteLine("Это числа {0} и {1}", b, c);
            Console.WriteLine("Это числа наоборот {1} и {0}", b, c);

            // Интерполяция строк
            Console.WriteLine($"Это числа {b} и {c}");
            Console.WriteLine($"Это числа наоборот {c} и {b}");

            // Delay.
            Console.ReadKey();
        }
    }
}
