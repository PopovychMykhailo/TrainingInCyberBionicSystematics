using System;

// Флаги форматирования строк.

namespace FlagFormating
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"C format: {99.9:C}");      // Вывод в денежном формате.
            Console.WriteLine($"F format: {99.935:##.##}");   // Вывод значений с фиксированой точностью.
            Console.WriteLine($"N format: {99999:N}");     // Стандартное числовое форматироваание.
            Console.WriteLine($"X format: {255:X}");       // Вывод в шеснадцатиричном формате.
            Console.WriteLine($"D format: {0xFF:D}");      // Вывод в десятичном формате.
            Console.WriteLine($"E format: {10000:E}");      // Вывод в экспоненциальном формате.
            Console.WriteLine($"G format: {99.9:G}");      // Вывод в общем формате.
            Console.WriteLine($"P format: {99.9:P}");      // Вывод в процентном формате.

            // Delay.
            Console.ReadKey();
        }
    }
}
