using System;
using System.Linq;
using System.Threading.Tasks;

// Простой запрос PLINQ. Класс - System.Linq.ParallelEnumerable

namespace PLINQ
{
    class Program
    {
        static void Main()
        {
            int[] array = new int[10000000];

            // Инициализация массива данных положительными значениями.
            Parallel.For(0, 10000000, (i) => array[i] = i);

            // Заполнение массива отрицательными значениями.
            array[1000] = -1;
            array[14000] = -2;
            array[15000] = -3;
            array[676000] = -4;
            array[8024540] = -5;
            array[9908000] = -6;

            // Запрос PLINQ для поиска отрицательных значений.
            ParallelQuery<int> negatives = from element in array.AsParallel()
                                           where element < 0
                                           select element;

            foreach (int element in negatives)
                Console.Write(element + " ");

            // Delay
            Console.ReadKey();
        }
    }
}
