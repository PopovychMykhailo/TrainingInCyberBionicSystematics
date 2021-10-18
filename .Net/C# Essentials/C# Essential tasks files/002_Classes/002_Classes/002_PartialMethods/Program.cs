using System;
using System.Text;

// Частичные методы (Partial methods).

namespace Classes
{
    class Program
    {
	    readonly int b;
	    static void Main()
        {
	        const int a = 13;

            Console.OutputEncoding = Encoding.Unicode;

            PartialClass instance = new PartialClass();

            instance.CallPartialMethod();

            // Delay.
            Console.ReadKey();
        }

	    public Program(int x)
	    {
            b = x;
	    }
    }
}
