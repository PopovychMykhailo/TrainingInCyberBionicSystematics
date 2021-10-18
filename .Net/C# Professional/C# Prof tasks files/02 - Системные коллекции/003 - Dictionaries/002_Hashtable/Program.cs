using System;
using System.Collections;
using System.Linq;

namespace HashtableDemo2
{
    class Program
    {
        static void Main()
        {
            var emailLookup = new Hashtable();

            emailLookup["sbishop@contoso.com"] = "Bishop, Scott";
            emailLookup["chess@contoso.com"] = "Hell, Christian";
            emailLookup["djump@contoso.com"] = "Jump, Dan";

            foreach (object name in emailLookup)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine(new string('-', 20));

            foreach (DictionaryEntry name in emailLookup)
            {
                Console.WriteLine(name.Value);
            }

            Console.WriteLine(new string('-', 20));

            foreach (object name in emailLookup.Values)
            {
                Console.WriteLine(name);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
