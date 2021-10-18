using System;

// Использование локальных областей и локальных переменных.

namespace LocalVariables
{
    class Program
    {
        static void Main()
        {
            int b = 10;
            Console.WriteLine(b);

            {
                int a = 1;
                Console.WriteLine(a);
                Console.WriteLine(b);
            }
				
            {
                int a = 2;
                Console.WriteLine(a);
                Console.WriteLine(b);
            }

            Console.ReadKey();
        }
    }
}
