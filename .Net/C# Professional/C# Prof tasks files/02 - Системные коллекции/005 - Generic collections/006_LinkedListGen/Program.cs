using System;
using System.Collections.Generic;

namespace LinkedListGen
{
    class Program
    {
        static void Main()
        {
            var links = new LinkedList<string>();

            LinkedListNode<string> first = links.AddFirst("First");
            LinkedListNode<string> last = links.AddLast("Last");
            LinkedListNode<string> afterlast = links.AddAfter(last,"After last");
            
            LinkedListNode<string> second = links.AddBefore(last, "Second");
            links.AddAfter(second, "Third");
   
            foreach (string s in links)
            {
                Console.WriteLine(s);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
