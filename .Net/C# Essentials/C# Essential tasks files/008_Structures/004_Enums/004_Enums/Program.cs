using System;

// Перечисления.

namespace Enums
{   
    class Program
    {
        // Enum, как аргумент метода
        public static void MethodEnum(EnumType e)
        {
            switch (e)
            {
                case EnumType.Zero:
                    Console.WriteLine("Число 0");
                    break;
                case EnumType.Two:
                    Console.WriteLine("Число 2");
                    break;
                case EnumType.Five:
                    Console.WriteLine("Число 5");
                    break;
                case EnumType.Ten:
                    Console.WriteLine("Число 10");
                    break;

                default: break;
            }
        } 

        static void Main()
        {
            MethodEnum(EnumType.Five);

            EnumType digit = EnumType.Ten;
            MethodEnum(digit);

            int i = (int)(++digit);
            Console.WriteLine(i);

            Console.WriteLine(digit); // Переменная изменилась.
            Console.WriteLine((int)EnumType.Ten); // Константа не изменилась.

            digit++;
            digit = digit + 5;

            // Недопустимо.
            //digit = ++EnumType.One;
            //digit = EnumType.One + EnumType.Two; 

            // Delay.
            Console.ReadKey();
        }
    }
}
