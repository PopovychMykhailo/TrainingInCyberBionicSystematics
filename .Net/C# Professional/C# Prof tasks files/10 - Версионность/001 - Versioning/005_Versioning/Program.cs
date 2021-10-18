using System;

// Замещение.

namespace ConsoleApplication1
{
    class BaseClass
    {
        public void SomeMetod1() { Console.WriteLine("1"); }

        public void SomeMetod2() { Console.WriteLine("2"); }
    }

    class DerivedClass : BaseClass
    {
        public new void SomeMetod1() { Console.WriteLine("3"); }

        public void SomeMetod2() { Console.WriteLine("4"); }
    }

    class Program
    {
        static void Main()
        {
            BaseClass instance1 = new DerivedClass();

            instance1.SomeMetod1();  // 1
            instance1.SomeMetod2();  // 2 

            DerivedClass instance2 = instance1 as DerivedClass;

            instance2.SomeMetod1();  // 3
            instance2.SomeMetod2();  // 4

            // Delay
            Console.ReadKey();
        }
    }
}
