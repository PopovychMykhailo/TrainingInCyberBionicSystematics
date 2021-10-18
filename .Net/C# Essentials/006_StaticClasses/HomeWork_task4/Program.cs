using System;

namespace HomeWork_task3
{
    class Program
    {
        /*
         * Используя Visual Studio, создайте проект по шаблону Console Application.
         * Требуется: создать расширяющий метод для целочисленного массива, который сортирует элементы
         * массива по возрастанию
        */

        static void Main(string[] args)
        {
            int[] array = { 5, 2, 4, 1, 3 };

            WorkerArray.SortAscending(array);

            Console.WriteLine("array");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine();


            int[] array2 = { 8, 9, 6, 10, 7 };
            array2.SortAscending();

            Console.WriteLine("array2");
            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write($"{array2[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
