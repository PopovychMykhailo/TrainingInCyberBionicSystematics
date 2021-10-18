using System;
using System.Text;

namespace ConsoleApplication1
{
    class BaseClass
    {
        public virtual void SomeMethods()
        {
            SomeMetod1();
            SomeMetod2();
        }

        public virtual void SomeMetod1() { Console.Write("1."); }
        public virtual void SomeMetod2() { Console.Write("2."); }
    }

    class DerivedClass : BaseClass
    {
        public new void SomeMethods()
        {
            SomeMetod1();
            SomeMetod2();
        }

        public new void SomeMetod1() { Console.Write("3."); }
        public override void SomeMetod2() { Console.Write("4."); }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.Write("Введите ключ - 0, 1 или 2: ");
                string s = Console.ReadLine();

                if (s == "0") // Версия: 1.2
                    new BaseClass().SomeMethods();

                if (s == "1") // Версия: 1.4
                    (new DerivedClass() as BaseClass).SomeMethods();

                if (s == "2") // Версия: 3.4                
                    new DerivedClass().SomeMethods();

                Console.WriteLine("\n");
            }
        }
    }
}
