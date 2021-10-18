using System;

// Math.Pow() - возведение числа в степень (1-ый аргумент - число, которое возводим в степень, 2-ой – показатель степени, в которую возводим число)

namespace MathPow
{
    class Program
    {
        static void Main()
        {
            double x = 2, y = 8;

            double result = Math.Pow(x, y);

            Console.WriteLine(result);
            // Delay.
            Console.ReadKey();
        }
    }
}
