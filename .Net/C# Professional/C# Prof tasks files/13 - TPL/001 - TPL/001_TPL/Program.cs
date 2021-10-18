using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    class Program
    {
        // Метод который будет выполнен асинхронно.
        static void MyTask()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine("\nMyTask: запущен в потоке # {0}", threadId);

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.Write("+ ");
            }

            Console.WriteLine("\nMyTask: завершен в потоке # {0}", threadId);
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            int threadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine("Main: запущен в потоке # {0}", threadId);

            Action action = new Action(MyTask);

            Task task = new Task(action); // Создание экземпляра задачи.            
            task.Start();                 // Запуск задачи на выполнение асинхронно.

            //task.RunSynchronously();    // Запуск задачи на выполнение синхронно.

            for (int i = 0; i < 10; i++)
            {
                Console.Write(". ");
                Thread.Sleep(200);
            }

            Console.WriteLine("\nMain: завершен в потоке # {0}", threadId);

            // Delay
            Console.ReadKey();
        }
    }
}
