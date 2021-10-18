using System;
using System.Text;

// Math.Sqrt() - математическая функция, которая извлекает квадратный корень

namespace MathSqrt
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            double x = -256;

            double result = Math.Sqrt(x);

            Console.Write("Квадратный корень равен: ");
            Console.WriteLine(result);

            // Delay.
            Console.ReadKey();
        }
    }
}
