using System;
using System.Text;

// Nested classes.

namespace Nested
{
    public class MyClass : BaseClass 
    {
        public class Nested // Наследование от BaseClass не распространяется.
        {
            public void MethodFromNested()
            {
                Console.WriteLine("Метод Nested класса.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            MyClass instance1 = new MyClass();
            instance1.MethodFromBase();

            MyClass.Nested instance2 = new MyClass.Nested();
            instance2.MethodFromNested();

            // Delay.
            Console.ReadKey();
        }
    }
}
