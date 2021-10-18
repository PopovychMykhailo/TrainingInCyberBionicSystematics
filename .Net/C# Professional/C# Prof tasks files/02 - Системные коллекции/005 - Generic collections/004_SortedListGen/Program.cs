using System;
using System.Collections.Generic;

namespace SortedListGen
{
    class Program
    {
        static void Main()
        {
            var sortList = new SortedList<string, int>();
            sortList["Zero"] = 0;
            sortList["One"] = 1;
            sortList["Two"] = 2;
            sortList["Three"] = 3;

            foreach (var i in sortList)
            {
                Console.WriteLine(i);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
