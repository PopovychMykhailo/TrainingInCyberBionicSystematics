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
            NotStaticClass instance = new NotStaticClass(1);


            NotStaticClass.Method();

            // Delay.
            Console.ReadKey();
        }
    }
}
