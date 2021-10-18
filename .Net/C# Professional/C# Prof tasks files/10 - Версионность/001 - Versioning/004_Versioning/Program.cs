using System;

// Перекрытие.

namespace ConsoleApplication1
{
    class BaseClass
    {
        public virtual void SomeMetod1() { Console.WriteLine("1"); }
        public virtual void SomeMetod2() { Console.WriteLine("2"); }
    }

    class DerivedClass : BaseClass
    {
        // Не является переопределением. NEW метод - (перекрытие)
        public new void SomeMetod1() { Console.WriteLine("3"); }
        public sealed override void SomeMetod2() { Console.WriteLine("4"); }
    }

    class Program
    {
        static void Main()
        {
            BaseClass instance = new DerivedClass();

            instance.SomeMetod1();  // 1
            instance.SomeMetod2();  // 4

            // Delay
            Console.ReadKey();
        }
    }
}
