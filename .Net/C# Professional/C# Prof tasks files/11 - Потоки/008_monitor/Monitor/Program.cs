using System;
using System.Threading;

// Ограничение: Нельзя использовать объекты блокировки структурного типа
// при работе с объектом класса - Monitor.

// Lock - не работает корректно с объектами блокировки структурных типов, 
// допускается использование объектов блокировки только ссылочных типов.

namespace monitor
{
    class Program
    {
        static int counter = 0;

        static int block = 0; // block - не должен быть структурным.

        static void Function()
        {
            for (int i = 0; i < 50; ++i)
            {
                // Устанавливается блокировка каждый (50!) раз в новый object (boxing).
                Monitor.Enter((object)block); // boxing создает новый объект (50! объектов).

                // Выполнение некоторой работы потоком ...
                Console.WriteLine(++counter);

                // Попытка снять блокировку с объекта который не является объектом блокировки.
                Monitor.Exit((object)block); // boxing создает абсолютно новый объект.
            }
        }

        static void Main()
        {
            Thread[] threads = { new Thread(Function), new Thread(Function), new Thread(Function) };

            foreach (Thread thread in threads)
                thread.Start();

            // Delay
            Console.ReadKey();
        }
    }
}
