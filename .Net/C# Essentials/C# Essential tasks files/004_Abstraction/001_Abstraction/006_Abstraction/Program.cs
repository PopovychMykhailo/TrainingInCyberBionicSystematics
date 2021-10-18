using System;
using System.Text;
using System.Xml.Serialization;

namespace Abstraction
{
    abstract class AbstractClass
    {
        // Конструктор (отрабатывает первым).
        public AbstractClass()
        {
            Console.WriteLine("1 AbstractClass()");

            // Вызывается реализация метода из производного класса - ConcreteClass.
            this.AbstractMethod();
            this.VirtualMethod();

            Console.WriteLine("2 AbstractClass()");
        }

        public virtual void VirtualMethod() 
        {
            Console.WriteLine("Default realization.");
        }

        public abstract void AbstractMethod();
    }

    class ConcreteClass : AbstractClass
    {
        string s = "FIRST";

        // Конструктор (отрабатывает вторым).
        public ConcreteClass()
        {
            Console.WriteLine("3 ConcreteClass()");
            s = "SECOND";
        }
        public override void VirtualMethod()
        {
            Console.WriteLine("Overrided метод VirtualMethod() в ConcreteClass  {0}", s);
        }

        public override void AbstractMethod()
        {
            Console.WriteLine("Реализация метода AbstractMethod() в ConcreteClass  {0}", s);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            AbstractClass instance = new ConcreteClass();

            Console.WriteLine(new string('-', 55));

            instance.AbstractMethod();

            // Задержка.
            Console.ReadKey();
        }
    }
}
