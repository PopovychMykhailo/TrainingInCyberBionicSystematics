using System;
using System.Text;

// Наследование абстрактных классов от интерфейсов.

namespace Interfaces
{
    interface Interface
    {
        void Method();
    }

    abstract class AbstractClass : Interface
    {
        // Реализация абстрактного метода из интерфейса, в абстрактном классе обязательна.
        public void Method()
        {
            Console.WriteLine("Метод - реализация интерфейса в абстрактном классе.");
        }
    }

    class ConcreteClass : AbstractClass
    {
    }

    class Program
    {
        static void Main()

        {
            Console.OutputEncoding = Encoding.Unicode;
            ConcreteClass instance = new ConcreteClass();
            instance.Method();

            // Delay.
            Console.ReadKey();
        }
    }
}
