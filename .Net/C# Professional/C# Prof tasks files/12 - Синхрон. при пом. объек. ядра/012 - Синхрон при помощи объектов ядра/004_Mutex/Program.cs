using System;
using System.Text;
using System.Threading;

// Использование Mutex для синхронизации доступа к защищенным ресурсам.

// Mutex - Примитив синхронизации, который также может использоваться 
// в межпроцессной и междоменной синхронизации.
// MutEx - Mutual Exclusion (Взаимное Исключение).

namespace MutexSample
{
    class Program
    {
        // Mutex - Примитив синхронизации, который также может использоваться в межпроцессорной синхронизации.
        // функционирует аналогично AutoResetEvent но снабжен дополнительной логикой:
        // 1. Запоминает какой поток им владеет. ReleaseMutex не может вызвать поток, который не владеет мьютексом.
        // 2. Управляет рекурсивным счетчиком, указывающим, сколько раз поток-владелец уже владел объектом.

        //static Mutex mutex = new Mutex(); // Отсутствует межпроцессная синхронизация. // 20 слайд.
        static Mutex mutex = new Mutex(false, "MyMutex"); // 19 слайд.

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Thread[] threads = new Thread[5];

            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(Function);
                threads[i].Name = i.ToString();
                Thread.Sleep(500); // Потоки из разных процессов успеют стать в очередь вперемешку.
                threads[i].Start();
            }

            // Delay
            Console.ReadKey();
        }

        static void Function()
        {
            mutex.WaitOne();

            Console.WriteLine("Поток {0} зашел в защищенную область.", Thread.CurrentThread.Name);
            Thread.Sleep(2000);
            Console.WriteLine("Поток {0}  покинул защищенную область.\n", Thread.CurrentThread.Name);

            mutex.ReleaseMutex();
        }
    }
}
