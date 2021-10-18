using System;
using System.Threading;
using System.Threading.Tasks;

namespace _018_AsyncLambda
{
    class Program
    {
        public static void Operation()
        {
            Console.WriteLine("Operation ThreadID {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Begin");
            Thread.Sleep(2000);
            Console.WriteLine("End");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main ThreadID {0}", Thread.CurrentThread.ManagedThreadId);

            Func<Task> lambda = async () =>
            {
                Console.WriteLine("Lambda I ThreadID {0}", Thread.CurrentThread.ManagedThreadId);

                var task = new Task(Operation);
                task.Start();
                await task;
                
                Console.WriteLine("Lambda II ThreadID {0}", Thread.CurrentThread.ManagedThreadId);
            };

            var task = lambda.Invoke();
            task.Wait();
            // Delay
            Console.ReadKey();
        }
    }
}
