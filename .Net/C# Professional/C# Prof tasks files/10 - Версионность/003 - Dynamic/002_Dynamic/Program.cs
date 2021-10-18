using System;

// dynamic

namespace Dynamic
{
    class MyClass
    {
        public void SomeMethod()
        {
            Console.WriteLine("MyClass.SomeMethod()");
        }
    }

    class Program
    {
        static void Main()
        {
            dynamic instance = new MyClass();
            instance.SomeMethod();

            // Delay.
            Console.ReadKey();
        }
    }
}
