using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// С завершением метода Main завершается недовыполненная задача MyTask
// [завершается работа вторичного потока].
// По умолчанию IsBackground == true

namespace TPL
{
    class Program
    {
        static void MyTask()
        {
            Thread.CurrentThread.IsBackground = false; // Снять комментарий.

            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Task task = new Task(MyTask);
            task.Start();

            Thread.Sleep(500); // Время на запуск задачи.

            Console.WriteLine("\nMain завершен.");

            // Delay
            //Console.ReadKey();
        }
    }
}
