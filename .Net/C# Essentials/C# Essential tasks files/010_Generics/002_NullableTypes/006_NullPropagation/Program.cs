using System;

namespace _006_NullPropagation
{
    class Node 
    {
        public Node Next { get; set; }

        public Node(Node next)
        {
            Next = next;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node instance = new Node(null);
            Node secondInstance = new Node(instance);
            secondInstance = new Node(secondInstance);
            secondInstance = new Node(secondInstance);
            secondInstance = new Node(secondInstance);

            // Попытка проверить, существует ли secondInstance.Next.Next.Next
            if (secondInstance != null 
                && secondInstance.Next != null 
                && secondInstance.Next.Next != null 
                && secondInstance.Next.Next.Next != null)
            {
                Console.WriteLine($"It is not null! HashCode: {secondInstance.Next.Next.Next.GetHashCode()}");
            }

            // Null Propagation
            if (secondInstance?.Next?.Next?.Next != null)
            {
                Console.WriteLine($"It is not null! HashCode: {secondInstance.Next.Next.Next.GetHashCode()}");
            }

            DateTime?[] array = new DateTime?[] { null, DateTime.Now };

            if (array?[0]?.Hour > 10)
            {
                Console.WriteLine("array?[0]?.Hour > 10 -> true");
            }
        }
    }
}
