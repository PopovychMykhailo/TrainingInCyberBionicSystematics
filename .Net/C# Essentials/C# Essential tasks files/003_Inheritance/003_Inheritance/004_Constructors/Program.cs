using System;

// Наследование.

namespace Inheritance
{
    class Program
    {
        static void Main()
        {
            DerivedClass instance = new DerivedClass();

            Console.WriteLine(instance.baseNumber);
            Console.WriteLine(instance.derivedField);

            // Delay.
            Console.ReadKey();
        }
    }
}
