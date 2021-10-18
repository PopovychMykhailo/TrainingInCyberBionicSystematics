using System.Collections.Generic;
using System;

namespace QueueAndStack
{
    class Program
    {
        static void Main()
        {
            var que = new Queue<string>();
            que.Enqueue("Hello");
            string queued = que.Dequeue();

            var serials = new Stack<double>();
            serials.Push(1);
            double serialNumber = serials.Pop();

            // Delay.
            Console.ReadKey();
        }
    }
}
