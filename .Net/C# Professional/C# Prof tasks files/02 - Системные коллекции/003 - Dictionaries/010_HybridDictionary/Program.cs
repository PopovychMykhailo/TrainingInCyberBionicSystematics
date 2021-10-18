using System;
using System.Collections;
using System.Collections.Specialized;

// HybridDictionary - Рекомендуется к использованию в тех случаях, когда невозможно определить размер коллекции заранее.

namespace HybridDictionaryDemo
{
    class Program
    {
        static void Main()
        {
            var emailLookup = new HybridDictionary();

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
