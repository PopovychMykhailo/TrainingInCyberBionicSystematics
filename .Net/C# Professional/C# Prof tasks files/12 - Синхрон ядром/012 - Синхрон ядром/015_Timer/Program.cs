using System;
using System.Text;
using System.Threading;

// Timer - предоставляет механизм для выполнения метода в заданные интервалы времени.

namespace TimerSample
{
    class Program
    {
        static int maxCount = 10;
        static int counter;

        void Function(Object state)
        {
            Console.WriteLine("Вызов метода {0}.", ++counter);

            if (counter >= maxCount)
            {
                counter = 0;                     // Обнуление счетчика.
                (state as AutoResetEvent).Set(); // Посылает сигнал первичному потоку - [продолжиться].
            }
        }

        void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            AutoResetEvent auto = new AutoResetEvent(false);
            TimerCallback callback = new TimerCallback(Function);

            Console.WriteLine("Период работы таймера 1/10 секунды.");

            // Аргументы:
            // 1. callback - делегат TimerCallback, представляющий callback метод. 
            // 2. auto - объект, передаваемый в качестве аргумента методу обратного вызова или значение null. 
            // 3. dueTime: 1000 - количество времени до начала вызова Function, в миллисекундах.
            //    [Timeout.Infinite - не допустить запуск таймера. Значение (0) - немедленный запуск таймера]
            // 4. period: 100 - интервал между вызовами параметра callback, в миллисекундах. 
            //    [Timeout.Infinite - отключение периодической сигнализации]
            Timer timer = new Timer(callback, auto, 1000, 100);

            auto.WaitOne();  // Остановка выполнения первичного потока.

            Console.WriteLine("\nПериод работы таймера 1/2 секунды.");

            // Аргументы:
            // 1. 0 - Количество времени, в миллисекундах, которое должно пройти до вызова callback метода.
            // 2. 500 - Временной интервал в миллисекундах между вызовами callback метода.
            timer.Change(0, 500);

            auto.WaitOne();  // Остановка выполнения первичного потока.

            Console.WriteLine("\nФинализация таймера.");
            timer.Dispose(); // Финализация таймера.

            // Delay
            Console.ReadKey();
        }
    }
}
