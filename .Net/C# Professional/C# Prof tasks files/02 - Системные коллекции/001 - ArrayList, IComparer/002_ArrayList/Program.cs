using System;
using System.Collections;

namespace ArrayListDemo
{
    class Program
    {
        static void Main()
        {
            var list = new ArrayList();

            list.Add("Hello");
            list.Add("Goodbye");

            // 1.
            for (int i = 0; i < list.Count; i++)
            {
	            //list.Remove("Hello");
                Console.WriteLine(list[i]);
            }

            // 2.
            IEnumerator enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            // 3.
            foreach (string item in list)
            {
                // Never do this!
                //list.Remove(item);
                //list.Add("Hello world!");
                Console.WriteLine(item);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
