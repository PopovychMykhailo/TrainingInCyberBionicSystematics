using System;
using System.Diagnostics;
using System.Runtime;
using System.Text;
using System.Threading;

// Серверный (параллельный) GC используется при наличии истинной многозадачности,
// для организации которой требуется многоядерный процессор.

// Параллельный GC является эффективным при работе с объектами у которых имеется деструктор, 
// для объектов без деструктора прироста в производительности не наблюдается.

// Для включения серверного режима CG, необходимо добавить следующую настройку в файл проекта .csproj: 
//     <ServerGarbageCollection>true</ServerGarbageCollection>

namespace ParallelGC
{
    class MyClass
    {
        // Для тестирования требуется закоментировать деструктор.
        ~MyClass()
        {
            Thread.Sleep(10000);
        }
    }
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Приложение обслуживает серверный (параллельный) GC = "
                + GCSettings.IsServerGC);

            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < 10000000; i++)
            {
                new MyClass();
            }

            timer.Stop();

            Console.WriteLine(timer.ElapsedMilliseconds);
        }
    }
}
