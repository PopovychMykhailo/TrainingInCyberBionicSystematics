using System;
using System.Threading;
using System.Threading.Tasks;

// Продолжение - автоматический запуск новой задачи, после завершения первой задачи.

namespace TPL
{
    class Program
    {
        // Метод который будет выполнен как задача.
        static void MyTask()
        {
            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(200);
                Console.Write("+");
            }
        }

        // Метод исполняемый как продолжение задачи.
        static void ContinuationTask(Task task)
        {
            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(200);
                Console.Write("-");
            }
        }

        static void Main()
        {
            // Создание задачи.
            Action action = new Action(MyTask);
            Task task = new Task(action);

            // Создание продолжения задачи.
            Action<Task> continuation = new Action<Task>(ContinuationTask);
            Task taskContinuation = task.ContinueWith(continuation);

            // Выполнение последовательности задач.
            task.Start();

            // Delay.
            Console.ReadKey();
        }
    }
}
