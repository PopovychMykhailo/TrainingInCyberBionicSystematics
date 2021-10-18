using System;

// Статический конструктор.

namespace Static
{
    class Program
    {
        static void Main()
        {
            // 1 Вариант. (Вызывается только Статический конструктор.)
            //NotStaticClass.StaticMethod();

            // 2 Вариант. (Вызываются оба Конструктора.)
            new NotStaticClass().NotStaticMethod();

            // Delay.
            Console.ReadKey();
        }
    }
}
