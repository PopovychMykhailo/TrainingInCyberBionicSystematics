using System;

// Базовый класс Object.

namespace ClassObject
{
    class MyClass
    {
        public override int GetHashCode()
        {            
            return 1234567890;
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass instance = new MyClass();

            Console.WriteLine(instance.GetHashCode());

            // Delay.
            Console.ReadKey();
        }
    }
}
