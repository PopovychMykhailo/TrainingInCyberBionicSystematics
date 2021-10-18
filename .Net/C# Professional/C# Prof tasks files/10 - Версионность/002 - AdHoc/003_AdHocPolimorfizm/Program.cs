using System;

namespace AdHocPolimorfizm
{

  class Program
    {
        static void Main()
        {
            object[] array = { new Class1(), new Class2(), new Class3() };

            foreach (dynamic i in array)
            {
                i.AbstractMethod();
                i.VirtualMethod();
                i.SimpleMethod();

                Console.WriteLine(new string('-', 50));
            }
                       
            // Delay.
            Console.ReadKey();
        }
    }
}
