using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Использование типов ParallelLoopResult и ParallelLoopState и
// метода Break() для параллельного выполнения цикла.

// ParallelLoopState - позволяет управлять итерациями параллельных циклов,
// экземпляр этого класса предоставляется каждому циклу автоматически.

// Метод parallelLoopState.Break() - прерывает выполнение цикла.

// ParallelLoopResult - предоставляет состояние выполнения цикла Parallel.

// Свойство parallelLoopResult.IsCompleted == true, если цикл доработал до конца,
// иначе, если цикл был прерван, то IsCompleted == false.

namespace TPL
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            int[] data = new int[100000000];

            // Инициализация массива начальными значениями.
            Parallel.For(0, data.Length, i => data[i] = i);

            data[300] = -1; // Помещение отрицательного значения в массив.

            Action<int, ParallelLoopState> transform = (int i, ParallelLoopState state) =>
            {
                if (data[i] < 0)   // ЕСЛИ: Отрицательное значение
                    state.Break(); // ТО:   Прервать цикл

                Thread.Sleep(1);

                data[i] = i * i * i / 123;
            };

            ParallelLoopResult loopResult = Parallel.For(0, data.Length, transform);

            if (!loopResult.IsCompleted)
            {
                Console.WriteLine("\nЦикл завершился преждевременно." +
                    " Элемент {0} имеет отрицательное значение.\n",
                    loopResult.LowestBreakIteration);
            }

            Console.WriteLine("Основной поток завершен.");
        }
    }
}
