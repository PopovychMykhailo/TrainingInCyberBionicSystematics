using System;
using System.Collections;

namespace HashtableDemo3
{
    class Program
    {
        static void Main()
        {
            var duplicates = new Hashtable();

            duplicates["First"] = "1st";
            duplicates["First"] = "the first";

            Console.WriteLine(duplicates.Count);
            Console.WriteLine(duplicates["First"]);

            // Delay.
            Console.ReadKey();
        }
    }
}
