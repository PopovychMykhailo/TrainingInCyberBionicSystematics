using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork_task1
{
    /* Technical task
    
        Создайте массив чисел размерностью в 1 000 000 или более. Используя генератор случайных
        чисел, проинициализируйте этот массив значениями. Создайте PLINQ запрос, который
        позволит получить все нечетные числа из исходного массива.
    */



    class Program
    {
        static void Main()
        {
            int[] array = new int[1_000_000];

            #region Fill the data array
            Action<int> fillCellArray = (int i) => { array[i] = i; };
            Parallel.For(0, array.Length, fillCellArray);
            #endregion


            #region We select the necessary data

            #region Create a PLINQ query
            // Variant 1
            ParallelQuery<int> oddValues = from cell in array.AsParallel()
                                           where (cell % 2 != 0)
                                           select cell;

            // Variant 1
            //ParallelQuery<int> oddValues = array.AsParallel().Where((int i) => { return (array[i] % 2) != 0; }).Select((int value) => { return value; });
            #endregion

            #region Implamantation query
            // Variant 1
            List<int> listOddValue = new(oddValues);

            // Variant 2
            //foreach (int item in oddValues)
            //    list.Add(item);
            #endregion

            #endregion

            Console.WriteLine($"Length of result array: {listOddValue.Count}");
        }
    }
}
