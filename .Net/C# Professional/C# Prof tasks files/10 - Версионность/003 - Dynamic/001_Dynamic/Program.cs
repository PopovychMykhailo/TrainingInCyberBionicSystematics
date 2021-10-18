using System;

// dynamic

namespace Dynamic
{
    class MyClass
    {
        public void SomeMethod()
        {
        }
    }

    class Program
    {
        static void Main()
        {
            object instance = new MyClass();
            //instance.SomeMethod();

            // Delay.
            Console.ReadKey();
        }
    }
}
