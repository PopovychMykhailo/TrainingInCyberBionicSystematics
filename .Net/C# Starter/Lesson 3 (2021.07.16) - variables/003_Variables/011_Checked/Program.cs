using System;

// Проверка переполнения - (checked)

namespace Checked
{
    class Program
    {
        static void Main()
        {
            sbyte a = 127;

            // Проверять переполнение.
            checked
            {
                a++; // ОШИБКА во время выполнения
            }

            // 127 + 1 = -128
            Console.WriteLine(a);

            // Delay.
            Console.ReadKey();
        }
    }
}
