using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace AsyncAwait
{
    class MyClass
    {
        int Operation()
        {
            Console.WriteLine("Операция выполняется в потоке ThreadID {0}",
                Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(2000);
            return 2 + 2;
        }

        public void OperationAsync()
        {
            AsyncStateMachine stateMachine;
            stateMachine.outer = this;
            stateMachine.builder = AsyncVoidMethodBuilder.Create();
            stateMachine.state = -1;
            stateMachine.builder.Start(ref stateMachine);
        }

        struct AsyncStateMachine : IAsyncStateMachine
        {
            public MyClass outer;
            public AsyncVoidMethodBuilder builder;
            public int state;

            TaskAwaiter<int> awaiter;

            void IAsyncStateMachine.MoveNext()
            {
                // Первая половина метода выполнится в первичном потоке.

                if (state == -1)
                {
                    Func<int> function = outer.Operation;
                    Task<int> task = Task<int>.Factory.StartNew(function);

                    state = 0;
                    awaiter = task.GetAwaiter();

                    builder.AwaitOnCompleted(ref awaiter, ref this);
                    return;
                }

                // Вторая половина метода выполнится во вторичном потоке.
                int result = awaiter.GetResult();
                Console.WriteLine("\nРезультат: {0}\n", result);
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                builder.SetStateMachine(stateMachine);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();
            my.OperationAsync();

            Console.WriteLine("Первичный поток завершил работу. ThreadID {0}",
                Thread.CurrentThread.ManagedThreadId);

            // Delay
            Console.ReadKey();
        }
    }
}
