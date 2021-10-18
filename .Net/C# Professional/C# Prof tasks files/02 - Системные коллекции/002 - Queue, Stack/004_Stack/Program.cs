using System;
using System.Collections;

namespace StackDemo2
{
    class Program
    {
        static void Main()
        {
            var stack = new Stack();

            stack.Push("First"); 
            stack.Push("Second");
            stack.Push("Third");
            stack.Push("Fourth");

            // Peek() - возвращает элемент с вершины стека, не удаляя его.
            if(stack.Peek() is string)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine(new string('-', Console.WindowWidth));
			// Count - возвращает количество элементов в стеке.
			while (stack.Count > 0)
			{
				Console.WriteLine(stack.Pop());
			}
			// Delay.
			Console.ReadKey();
        }
    }
}
