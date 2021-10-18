using System;
using System.Collections;

namespace Reg
{
    class Program
    {
        static void Main()
        {
            var inTable = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
            inTable["hello"] = "Hi";
            inTable["HELLO"] = "Heya";
            Console.WriteLine(inTable.Count); // 1

            var inList = new SortedList(StringComparer.InvariantCultureIgnoreCase);
            inList["hello"] = "Hi";
            inList["HELLO"] = "Heya";
            Console.WriteLine(inList.Count); // 1

            // Delay.
            Console.ReadKey();
        }
    }
}
