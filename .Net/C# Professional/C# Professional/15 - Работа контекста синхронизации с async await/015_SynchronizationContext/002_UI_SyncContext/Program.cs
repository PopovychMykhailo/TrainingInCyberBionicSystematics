using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UI_SyncContext
{
    internal class Program
    {
        static Program()
        {
            SynchronizationContext.SetSynchronizationContext(new ConsoleSynchronizationContext());
        }

        private static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Message message = new Message(ApplicationMain, null);
            MessageListenter.AddMessage(message);

            new MessageListenter().Listen();

            Console.ReadKey();
        }

        private static  void ApplicationMain(object _)
        {
            Console.WriteLine($"Наш метод Main начал свою работу в потоке {Thread.CurrentThread.ManagedThreadId}");

            StubMethod1();

             MethodAsync();

            StubMethod2();

            Console.WriteLine($"Наш метод Main закончил свою работу в потоке {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task MethodAsync()
        {
            Console.Write(new string('-', 80));

            Console.WriteLine($"Код до оператора await выполнен в потоке {Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(Method);
            Console.WriteLine($"Код после оператора await выполнен в потоке {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine(new string('-', 80));
        }
        private static void StubMethod1()
        {
            Console.WriteLine($"Пример метода1!!! Id потока: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void StubMethod2()
        {
            Console.WriteLine($"Пример метода2!!! Id потока: {Thread.CurrentThread.ManagedThreadId}");
        }


        private static void Method()
        {
            Console.WriteLine($"Метод {nameof(Method)} был выполнен в потоке {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
