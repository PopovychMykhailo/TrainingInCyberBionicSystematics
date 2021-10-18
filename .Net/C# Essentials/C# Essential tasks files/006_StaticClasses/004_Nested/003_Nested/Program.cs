using System;

// Nested classes.

namespace Nested
{
    class MyClass
    {
        private int field = 0;

        public class Nested
        {
            MyClass instance = new MyClass();

            public void Method(int a)
            {
                instance.field = a;

                Console.WriteLine(instance.field);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass.Nested instance = new MyClass.Nested();

            instance.Method(1);

            // Delay.
            Console.ReadKey();
        }
    }
}
