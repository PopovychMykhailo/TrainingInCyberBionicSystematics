using System;
using System.Text;

// Условная конструкция - if-else (с двумя ветвями).

namespace Condition
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            int a = 1, b = 2;

            // Если тело блока if или else состоит из одного выражения, то операторные скобки можно опустить

            if (a < b)
                Console.WriteLine("a < b");           // Ветвь 
            else
                Console.WriteLine("a не меньше b");   // Ветвь 2

            // Delay.
            Console.ReadKey();
        }
    }
}
