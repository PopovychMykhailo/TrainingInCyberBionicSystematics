using System;
using System.Text;

// Nested classes.

namespace Nested
{
    public class MyClass // Наследование от BaseClass не распространяется.
    {
        public class Nested : BaseClass
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
            MyClass.Nested instance = new MyClass.Nested();

            instance.MethodFromBase();
            instance.MethodFromNested();

            // Delay.
            Console.ReadKey();
        }
    }
}
