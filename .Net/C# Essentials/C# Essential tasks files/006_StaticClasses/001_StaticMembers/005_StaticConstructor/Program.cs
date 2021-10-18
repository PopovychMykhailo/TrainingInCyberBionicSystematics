using System;
using System.Text;

// Статический конструктор.

namespace Static
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(NotStaticClass.ReadonlyField);

            // Delay.
            Console.ReadKey();
        }
    }
}
