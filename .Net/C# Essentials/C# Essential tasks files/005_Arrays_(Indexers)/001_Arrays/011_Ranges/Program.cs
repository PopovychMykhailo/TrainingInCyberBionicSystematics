using System;
using System.Text;

namespace _011_Ranges
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            int[] array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine("Исходный массив:");
            PrintArray(array);

            int[] formStartToFourth = array[..4];
            Console.WriteLine("Диапазон элементов массива [..4] - новый массив элементов c первого элемента массива по элемент с индексом [4] не включая элемент по индексу [4]:");
            PrintArray(formStartToFourth);

            int[] formFourthToEnd = array[4..];
            Console.WriteLine("Диапазон элементов массива [4..] - новый массив элементов c элемента массива с индексом [4] до конца массива:");
            PrintArray(formFourthToEnd);

            int[] elementsFromThirdToFifth = array[3..5];
            Console.WriteLine("Диапазон элементов массива [3..5] - новый массив элементов от элемента по индексу [3] включительно до элемента по индексу [5] не включая элемент по индексу [5]:");
            PrintArray(elementsFromThirdToFifth);

            int[] fromFifthFromEndToFirstFromEnd = array[^5..^1];
            Console.WriteLine("Диапазон элементов массива [^5..^1] - новый массив элементов от элемента по индексу [^5] включительно до элемента по индексу [^1] не включая элемент по индексу [^1]:");
            PrintArray(fromFifthFromEndToFirstFromEnd);

            Range range = Range.StartAt(4);
            Console.WriteLine("Диапазон элементов массива Range.StartAt(4):");
            PrintArray(array[range]);
        }

        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }
    }
}
