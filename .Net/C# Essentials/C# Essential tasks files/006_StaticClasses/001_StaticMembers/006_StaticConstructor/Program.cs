using System;
using System.Text;

// Статические члены в нестатических классах.

namespace Static
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            NotStaticClass instance = new NotStaticClass();
            instance.NotStaticMethod();

            //NotStaticClass.Property = 2;
            //Console.WriteLine(NotStaticClass.Property);

            //NotStaticClass.Method();
            //NotStaticClass.Method(3);

            // Delay.
            Console.ReadKey();
        }
    }
}
