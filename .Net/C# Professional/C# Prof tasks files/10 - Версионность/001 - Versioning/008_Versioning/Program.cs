using System;

namespace ConsoleApplication1
{
    class BaseClass
    {
        public virtual void SomeMetod1() { Console.WriteLine("1"); }
        public virtual void SomeMetod2() { Console.WriteLine("2"); }
    }

    class DerivedClass : BaseClass
    {
        // Без NEW срабатывает как с NEW - НО, предупреждение компилятора.
        public void SomeMetod1() { Console.WriteLine("3"); }
        public override void SomeMetod2() { Console.WriteLine("4"); }
    }

    class DerivedFromDerivedClass : DerivedClass { }


    class Program
    {
        static void Main()
        {
            Console.WriteLine("BaseClass");

            BaseClass i1 = new DerivedClass();
            i1.SomeMetod1();  // 1
            i1.SomeMetod2();  // 4


            Console.WriteLine("DerivedClass");

            DerivedClass i2 = new DerivedClass();
            i2.SomeMetod1();  // 3
            i2.SomeMetod2();  // 4


            Console.WriteLine("DerivedFromDerivedClass");

            DerivedFromDerivedClass i3 = new DerivedFromDerivedClass();
            i3.SomeMetod1();  // 3
            i3.SomeMetod2();  // 4

            // Delay
            Console.ReadKey();
        }
    }
}
