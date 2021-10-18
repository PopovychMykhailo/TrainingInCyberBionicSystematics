using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Classwork_task1
{

    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Создайте метод, который в качестве аргумента принимает массив целых чисел и возвращает коллекцию
        всех четных чисел массива. Для формирования коллекции используйте оператор yield.
    */

    class Program
    {
        static void Main(string[] args)
        {
            //int[] arrayNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };


            IEnumerable<int> collection = GeneratorIEnumerable(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });

            foreach (var item in collection)
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine();
            Console.WriteLine();

        }

        public static IEnumerable<int> GeneratorIEnumerable(int[] arrayNumbers)
        {
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                if (arrayNumbers[i] % 2 == 0)
                    yield return arrayNumbers[i];
            }
        }
    }
}
