using System;
using System.Collections;
using System.Collections.Specialized;

//ListDictionary - Подходит для хранения небольшого количества элементов, поскольку организована по принципу обычного массива.

namespace ListDictionaryDemo
{
    class Program
    {
        static void Main()
        {
            var emailLookup = new ListDictionary();

            emailLookup["sbishop@contoso.com"] = "Bishop, Scott";
            emailLookup["chess@contoso.com"] = "Hell, Christian";
            emailLookup["djump@contoso.com"] = "Jump, Dan";

            foreach (DictionaryEntry entry in emailLookup)
            {
                Console.WriteLine(entry.Value);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
