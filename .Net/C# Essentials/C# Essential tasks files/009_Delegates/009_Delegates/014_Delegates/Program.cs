using System;

// Рекурсия в лямбда операторах.

namespace Delegates
{
    delegate void MyDelegate(int argument);

    class Program
    {
        static void Main()
        {
            MyDelegate my = null; // Требуется обязательно присвоить null.

            // Требуется отдельное присвоение ссылки на делегат с сообщенным лямбда оператором,
            // в месте создания переменной, недопустимо сразу создавать лямбда оператор.

            my = (int i) =>
            {
                i--;
                Console.WriteLine("Begin {0}", i);

                if (i > 0)
                {
                    my(i);
                }

                Console.WriteLine("End {0}", i);
            };

            my(3);

            // Delay.
            Console.ReadKey();
        }
    }
}
