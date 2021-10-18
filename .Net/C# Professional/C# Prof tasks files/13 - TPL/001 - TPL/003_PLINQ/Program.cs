using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Отмена параллельного запроса. (Выполняться через Ctrl + F5)

namespace PLINQ
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            CancellationTokenSource cancellation = new CancellationTokenSource();
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
            ParallelQuery<int> negatives = from element in array
                                               .AsParallel()
                                               .WithCancellation(cancellation.Token)
                                           where element < 0
                                           select element;

            // Отмена выполнения запроса PLINQ по истечении 10 миллисекунд.
            cancellation.CancelAfter(10);

            try
            {
                foreach (int element in negatives)
                    Console.Write(element + " ");

                Console.WriteLine("Перечисление завершено успешно!");
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cancellation.Dispose();
            }

            // Delay
            Console.ReadKey();
        }
    }
}
