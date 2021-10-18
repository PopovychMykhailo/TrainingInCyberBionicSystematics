using System;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using System.Text;

namespace TaskSchedulerAwait
{
    internal class Program
    {
        private static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.SetWindowSize(90, 40);

            ShowData("Main выполнился до await");

            var mainTask = new Task<Task>(MethodAsync);
            mainTask.Start(new AwaitableTestTaskScheduler());
            var result = await mainTask;                    // await await mainTask;
            await result;

            ShowData("Main выполнился после await");
            
            Console.ReadKey();
        }

        private static async Task MethodAsync()
        {
            ShowData("MethodAsync выполнился до await");

            var task = new Task(TestMethod);
            task.Start();

            await task;

            ShowData("MethodAsync выполнился после await");
        }

        private static void TestMethod()
        {
            ShowData("TestMethod выполнился");
        }

        private static void ShowData(string description)
        {
            Console.WriteLine($"{description}");

            Console.WriteLine($"Имя потока: {Thread.CurrentThread.Name} ");
            Console.WriteLine($"Id потока: {Thread.CurrentThread.ManagedThreadId}. Поток из пула потоков: {Thread.CurrentThread.IsThreadPoolThread}");
            Console.WriteLine($"Id задачи: {Task.CurrentId}");
            Console.WriteLine($"Текущий планировщик задач: {typeof(TaskScheduler).GetProperty("InternalCurrent", BindingFlags.Static | BindingFlags.NonPublic).GetValue(typeof(TaskScheduler))}");

            Console.WriteLine(new string('-', 80));
            Console.WriteLine();
        }
    }
}
