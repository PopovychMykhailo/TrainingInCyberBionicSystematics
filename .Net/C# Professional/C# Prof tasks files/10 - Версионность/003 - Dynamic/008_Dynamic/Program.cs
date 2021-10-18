using System;

// dynamic

namespace Dynamic
{
    class MyClass
    {
        static public void Method(string str)
        {
            Console.WriteLine("STRING...");
        }

        static public void Method(int i)
        {
            Console.WriteLine("INTEGER...");
        }

        //static public void Method(AnotherClass i)
        //{
        //    Console.WriteLine("AnotherClass...");
        //}
    }

    class AnotherClass
    {
    }

    class Program
    {
        static void Main()
        {
            MyClass.Method("Hello");

            MyClass.Method(10);

            dynamic ac = new AnotherClass();

            MyClass.Method(ac); // Exception.

            // Delay.
            Console.ReadKey();
        }
    }
}
