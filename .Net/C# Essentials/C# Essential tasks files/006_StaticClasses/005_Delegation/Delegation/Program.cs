using System;

// Техника Делегирования.

namespace Delegation
{
    class A
    {
        public string DoSomething(string shoes)
        {
            return shoes + "iii";
        }
    }

    class B
    {
        public string DoSomething(string temshoes)
        {
            A a = new A();
            return a.DoSomething(temshoes);
        }
    }

    class Program
    {
        static void Main()
        {
            B b = new B();
            string myShoe = "b>";
            string myShoeRepair = b.DoSomething("b>");
            Console.WriteLine(myShoeRepair);

            // Delay.
            Console.ReadKey();
        }
    }
}
