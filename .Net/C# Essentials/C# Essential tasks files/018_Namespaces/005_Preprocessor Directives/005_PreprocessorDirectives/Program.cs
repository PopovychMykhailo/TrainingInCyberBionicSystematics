using System;

namespace PreprocessorDirectives
{
    class Program
    {
        static void Main()
        {

            // #warning позволяет создавать предупреждение первого уровня из определенного места в коде.
            // Посмотреть окно Ошибок, вкладкa - Предупреждения.
#warning Пользовательское предупреждение.
            Console.WriteLine("Hello World!");

            // Delay.
            Console.ReadKey();
        }
    }
}
