using System;
using System.Collections;

namespace ArrayListDemo
{
    class Program
    {
        static void Main()
        {
            var myInts = new ArrayList {1, 2, 3};

            foreach (object i in myInts)
            {
                var number = (int)i;
                Console.WriteLine(number);
            }

            myInts.Add("Four");

            // Delay.
            Console.ReadKey();
        }
    }
}
