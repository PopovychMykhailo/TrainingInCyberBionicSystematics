using System;
using System.Collections.Generic;
using System.Linq;
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
    class Element
    {
        public int A { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            IList<Element> elements =
                Enumerable.Range(0, 10000)
                .Select(x => new Element()
                {
                    A = x
                }).ToList();

            elements[300].A = -1; // Помещение отрицательного значения в коллекцию.

            Action<Element, ParallelLoopState> transform = (Element element, ParallelLoopState state) =>
            {
                if (element.A < 0)  // ЕСЛИ: Отрицательное значение
                    state.Break();  // ТО:   Прервать цикл

                Thread.Sleep(1);

                element.A = 111 * 222 * 333 / 444;
            };

            // Использование цикла, параллельно выполняемого методом ForeEach, для отображения данных на экране.
            ParallelLoopResult loopResult = Parallel.ForEach(elements, transform);

            if (!loopResult.IsCompleted)
            {
                Console.WriteLine("\nОбход коллекции завершился преждевременно." +
                    " Элемент {0} имеет отрицательное значение.\n",
                    loopResult.LowestBreakIteration);
            }

            Console.WriteLine("Основной поток завершен.");
        }
    }
}
