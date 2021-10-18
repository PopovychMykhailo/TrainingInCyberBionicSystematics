using System;
using System.Text;

// Множественное наследование.

namespace Interfaces
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Interface1 instance1 = new DerivedClass();
            Interface2 instance2 = new DerivedClass();

            instance1.Method1();
            // instance1.Method2();
            
            instance2.Method2();
            // instance2.Method1();

            // Delay.
            Console.ReadKey();
        }
    }
}
