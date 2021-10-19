using System;
using System.Collections;
using System.Linq;

namespace Classwork_task1
{
    /* Technical task

        Cоздайте метод, который в качестве аргумента принимает массив целых чисел и возвращает
        коллекцию квадратов всех нечетных чисел массива. Для формирования коллекции используйте
        оператор yield.
    */




    class Program
    {
        static void Main()
        {
            IEnumerable oddNumbers = GetOddNumbers(new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            foreach (var item in oddNumbers)
            {
                Console.WriteLine(item);
            }
        }


        static IEnumerable GetOddNumbers(int[] array)
        {
            foreach (var item in array)
            {
                if (item % 2 != 0)
                    yield return (item * item);
            }
        }
    }
}
