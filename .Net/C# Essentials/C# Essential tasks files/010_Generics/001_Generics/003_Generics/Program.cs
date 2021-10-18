using System;
using System.Text;

// Универсальные шаблоны. (Универсальный метод)

namespace Generics
{
    class MyClass
    {
        public void Method<T>(T argument)
        {
            T variable = argument;

            Console.WriteLine(variable);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            MyClass instance = new MyClass();

            instance.Method<string>("Hello world!");

            instance.Method("Привет мир!");

            // Delay.
            Console.ReadKey();
        }
    }
}
