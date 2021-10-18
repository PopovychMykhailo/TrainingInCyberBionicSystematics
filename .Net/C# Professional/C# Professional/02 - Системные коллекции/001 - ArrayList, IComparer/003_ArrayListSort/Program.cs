using System;
using System.Collections;

namespace ArrayListSort
{
    class Program
    {
        static void Main()
        {
            var list = new ArrayList();

            list.Add(2);
            list.Add(3);
            list.Add(1);

            // QuickSort 
            list.Sort();

            foreach (int item in list)
            {
                Console.WriteLine(item);
            }

            // Задержка.
            Console.ReadKey();
        }
    }
}
