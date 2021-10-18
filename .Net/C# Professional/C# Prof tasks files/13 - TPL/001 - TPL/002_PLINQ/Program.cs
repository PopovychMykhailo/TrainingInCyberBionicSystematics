using System;
using System.Linq;
using System.Threading.Tasks;

// Запрос PLINQ. Использование метода AsOrdered().

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

            // Запрос PLINQ для поиска отрицательных значений с использованием метода AsOrdered() 
            // для сохранения порядка в результирующей последовательности.
            var negatives = array.AsParallel().AsOrdered().Where(element => element < 0);

            foreach (var element in negatives)
                Console.Write(element + " ");

            // Delay
            Console.ReadKey();
        }
    }
}
