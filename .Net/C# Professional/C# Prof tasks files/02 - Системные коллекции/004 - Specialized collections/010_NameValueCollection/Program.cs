using System;
using System.Collections.Specialized;

namespace NameValueCollectionDemo
{
    class Program
    {
        static void Main()
        {
            var nv = new NameValueCollection
                                         {
                                             {"First", "1st"}, 
                                             {"Second", "2nd"}, 
                                             {"Second", "SECOND"}
                                         };

            //foreach (string item in nv.GetValues("Second"))
            foreach (string item in nv)
            {
                string[] itemValues = nv.GetValues(item);
                Console.WriteLine("Key: {0}",item);
                if (itemValues != null)
                    foreach (string itemValue in itemValues)
                    {
                        Console.WriteLine("\tValue: {0}",itemValue);
                    }
            }

            Console.WriteLine(new string('-', 20));

            for (int x = 0; x < nv.Count; ++x)
            {
                Console.WriteLine(nv[x]);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
