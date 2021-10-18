using System;
using System.Text;

// Условная конструкция - if - else (с двумя ветвями).

namespace Condition
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            int a = 1, b = 2;

            if (a < b)  // Если условие удовлетворяет истинности, выполняем тело блока if.
            {
                Console.WriteLine("a < b");               // Ветвь 1
            }
            else        // Иначе, выполняем тело блока else.       
            {
                Console.WriteLine("a не меньше b");       // Ветвь 2
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
