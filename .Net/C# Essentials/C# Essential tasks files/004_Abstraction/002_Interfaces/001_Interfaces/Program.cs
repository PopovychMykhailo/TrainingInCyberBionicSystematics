using System;
using System.Text;

// Интерфейсы.

namespace Interfaces
{
    interface IInterface
    {
        void Method();
    }

    class MyClass : IInterface
    {
        public void Method()
        {
            Console.WriteLine("Метод - реализация Интерфейса.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            IInterface my = new MyClass();

            my.Method();

            //Delay.
            Console.ReadKey();
        }
    }
}
