using System;

// Структуры. Наследование.

// Наследование структур разрешено только от интерфейсов.
// Наследование структур, от классов и структур запрещено.

namespace Inheritance
{
    interface IInterface
    {
        void Method();
    }

    struct MyStruct : IInterface
    {
        public void Method()
        {
            Console.WriteLine("Method");
        }
    }

    class Program
    {
        static void Main()
        {
            MyStruct instance;

            instance.Method();

            // Delay.
            Console.ReadKey();
        }
    }
}
