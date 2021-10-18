using System;
using System.Collections;

namespace QueueDemo
{
    class Program
    {
        static void Main()
        {
            var queue = new Queue();
            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");
            queue.Enqueue("Fourth");

            // Peek() - возвращает первый элемент из очереди не удаляя его.
            object element = queue.Peek();
            Console.WriteLine(element as string); //First

            Console.WriteLine(new string('-', 10));

            if (element is string)
            {
                Console.WriteLine(queue.Dequeue());  // First.
            }



            // Count - возвращает количество элементов в очереди.
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue()); // Second, Third, Fourth.
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
