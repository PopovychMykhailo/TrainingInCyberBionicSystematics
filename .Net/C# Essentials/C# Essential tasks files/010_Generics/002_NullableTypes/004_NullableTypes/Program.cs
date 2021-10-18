using System;

namespace NullableTypes
{
    // Значение по умолчанию для NullableTypes == null.

    class Program
    {
        static int? i;

        static void Main()
        {
            if (i == null)
            {
                Console.WriteLine("null");
            }
            else if (i == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine("Другое...");
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
