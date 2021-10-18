using System;

// Базовый класс Object.

namespace ClassObject
{
    class MyClass : object
    {
        public override string ToString()
        {
            return "Hello world!";
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass instance = new MyClass();

            Console.WriteLine(instance);

            // Delay.
            Console.ReadKey();
        }
    }
}
