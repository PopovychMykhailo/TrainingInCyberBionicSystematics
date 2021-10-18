using System;
using System.Text;

// Nested classes.

namespace Nested
{
    class MyClass
    {

        public void DoSomething() 
        {
            var temporary = new Nested();
        }

        public class Nested
        {
            public void Method()
            {
                Console.WriteLine("Метод из Nested класса");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            MyClass.Nested instance = new MyClass.Nested();

            instance.Method();

            // Delay.
            Console.ReadKey();
        }
    }
}
