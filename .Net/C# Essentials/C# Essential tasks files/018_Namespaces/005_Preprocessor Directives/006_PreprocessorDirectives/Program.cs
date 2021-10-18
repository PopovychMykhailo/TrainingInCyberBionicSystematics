using System;

namespace PreprocessorDirectives
{
    class Program
    {
        static void Main()
        {
            // #error - позволяет создавать ошибку первого уровня из определенного места в коде.

//#error Ошибка определенная пользователем. // Снять комментарий.
            Console.WriteLine(1);


            // Delay.
            Console.ReadKey();
        }
    }
}
