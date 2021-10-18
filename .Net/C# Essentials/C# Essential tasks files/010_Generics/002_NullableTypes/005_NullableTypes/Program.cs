using System;

namespace NullableTypes
{
    class Program
    {
        static void Main()
        {
            Nullable<int> a = 1;
             
            if (a.HasValue == true)
            {
                Console.WriteLine("a is {0}.", a.Value);
            }

            // Короткая нотация Nullable типа - "?", доступна только для C#.
            int? b = 1;

            if (b.HasValue == true)
            {
                Console.WriteLine("b is {0}", b.Value);
            }

            // Неявно типизированная локальная переменная не может быть - Nullable.
            // var? c = null;        

            // Delay.
            Console.ReadKey();
        }
    }
}
