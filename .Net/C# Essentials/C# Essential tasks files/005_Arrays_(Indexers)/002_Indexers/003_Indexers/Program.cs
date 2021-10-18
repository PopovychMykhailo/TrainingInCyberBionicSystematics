using System;
using System.Text;

// Индексаторы.

namespace Indexers
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            MyClass my = new MyClass();

            for (int i = 0; i < 6; i++)
            {
                my[i] = string.Format("string {0}", i);
            }
            
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(my[i]); 
            }
            
            // Delay.
            Console.ReadKey();
        }
    }
}
