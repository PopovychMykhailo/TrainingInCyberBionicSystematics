using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Отмена задачи с использованием опроса. (Пример выполнять через CTRL+F5)

namespace TPL
{
    class Program
    {
        static void MyTask(object arg)
        {
            CancellationToken token = (CancellationToken)arg;

            // Если задача сразу после старта отменена - возбудить OperationCanceledException.
            token.ThrowIfCancellationRequested();

            Console.WriteLine("MyTask запущен.");

            for (int i = 0; i < 80; i++)
            {
                if (token.IsCancellationRequested) // Задача отменена?
                {
                    Console.WriteLine("\nПолучен запрос на отмену задачи.");
                    token.ThrowIfCancellationRequested(); // Возбудить OperationCanceledException.
                }

                Thread.Sleep(100);
                Console.Write(".");
            }

            Console.WriteLine("\nMyTask завершен.");
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Основной поток запущен.");

            // Создать источник токенов отмены.
            CancellationTokenSource cancellation = new CancellationTokenSource();
            CancellationToken token = cancellation.Token;

            Task task = new Task(MyTask, token);
            task.Start();

            Thread.Sleep(2000);

            try
            {
                cancellation.Cancel(); // Отмена выполняемой задачи.
                task.Wait(); // Для обработки исключения обязательно вызвать Wait!
            }
            catch (AggregateException e)
            {
                if (task.IsCanceled)
                    Console.WriteLine("\nЗадача отменена.\n");

                Console.WriteLine("Inner Exception : " + e.InnerException.GetType());
                Console.WriteLine("Message         : " + e.InnerException.Message);
                Console.WriteLine("Статус задачи   : " + task.Status);
            }

            Console.WriteLine("Основной поток завершен.");

            // Delay
            Console.ReadKey();
        }
    }
}
