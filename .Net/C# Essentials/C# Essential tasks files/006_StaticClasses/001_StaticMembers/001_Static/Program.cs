using System;

// Статические члены в нестатических классах.

namespace Static
{
    class Program
    {
        static void Main()
        {
            NotStaticClass instance1 = new NotStaticClass(1);
            NotStaticClass instance2 = new NotStaticClass(2);

            instance1.Method();
            instance2.Method();

            // На классе-объекте NotStaticClass, обращаемся к статическому полю - field
            NotStaticClass.field = 1;

            instance1.Method();
            instance2.Method(); 

            // Delay.
            Console.ReadKey();
        }
    }
}
