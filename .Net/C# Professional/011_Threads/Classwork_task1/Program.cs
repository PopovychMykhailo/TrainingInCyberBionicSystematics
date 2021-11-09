using System;
using System.Threading;

namespace Classwork_task1
{
    /* Technical task
    
        Используя конструкции блокировки, модифицируйте последний пример урока таким образом,
        чтобы получить возможность поочередной работы 3-х потоков.
    */



    class Program
    {
        static int counter = 0;

        static object block = 0; // block - був int, а треба щоб був ссилочного типу: object

        static void Function()
        {
            for (int i = 0; i < 50; ++i)
            {
                // Устанавливается блокировка каждый (50!) раз в новый object (boxing).
                Monitor.Enter((object)block); // boxing создает новый объект (50! объектов).

                // Выполнение некоторой работы потоком ...
                Console.WriteLine($"{++counter} ");

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
