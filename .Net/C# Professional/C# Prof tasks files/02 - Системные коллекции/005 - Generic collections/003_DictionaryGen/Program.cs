using System;
using System.Collections.Generic;

namespace DictionaryGen
{
    class Program
    {
        static void Main()
        {
            var dict = new Dictionary<int, string>();
                dict[3] = "Three";
                dict[4] = "Four";
                dict[1] = "One";
                dict[2] = "Two";
                dict[2] = "Tw1o";
            string str = dict[3];

            foreach (KeyValuePair<int, string> i in dict)
            {
                Console.WriteLine("{0} = {1}", i.Key, i.Value);
            }

            Console.WriteLine(new string('-', 25));

            foreach (var value in dict.Values)
            {
                Console.WriteLine(value);
            }

            

            // Delay.
            Console.ReadKey();
        }
    }
}
