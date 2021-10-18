using System;

// Динамические типы данных. (Динамические типы в параметризированных делегатах)

namespace Dynamic
{
    delegate R MyDelegate<T, R>(T argument);

    class Program
    {
        static dynamic Method(dynamic argument)
        {
            return argument;
        }

        static void Main()
        {
            dynamic myDelegate = new MyDelegate<dynamic, dynamic>(Method);

            dynamic @string = myDelegate("Hello world!");

            Console.WriteLine(@string);

            // Delay.
            Console.ReadKey();
        }
    }
}
