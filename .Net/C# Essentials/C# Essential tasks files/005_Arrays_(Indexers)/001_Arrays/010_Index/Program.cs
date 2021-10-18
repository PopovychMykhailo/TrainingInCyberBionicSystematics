using System;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace _010_Index
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            int[] array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

            Console.WriteLine();

            int firstElement = array[0];
            Console.WriteLine("Элемент массива по индексу [0]:");
            Console.WriteLine(firstElement);

            var lastElement = array[^1];
            Console.WriteLine("Элемент массива по индексу [^1] - то же самое, что [длинна массива - 1]:");
            Console.WriteLine(lastElement);

            var secondFromEnd = array[^2];
            Console.WriteLine("Элемент массива по индексу [^2] - то же самое, что [длинна массива - 2]:");
            Console.WriteLine(secondFromEnd);

            Index index = Index.FromEnd(3);
            Console.WriteLine("Элемент массива по индексу Index.FromEnd(3):");
            Console.WriteLine(array[index]);
        }
    }
}
