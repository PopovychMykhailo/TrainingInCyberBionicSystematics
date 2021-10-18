using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace AsyncAwait
{
    class MyClass
    {
        public void Operation()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Основная задача");
        }

        public Task OperationAsync()
        {
            AsyncStateMachine stateMachine;
            stateMachine.outer = this;
            stateMachine.builder = AsyncTaskMethodBuilder.Create();
            stateMachine.state = -1;
            stateMachine.builder.Start(ref stateMachine);

            return stateMachine.builder.Task;
        }

        private struct AsyncStateMachine : IAsyncStateMachine
        {
            //public AsyncVoidMethodBuilder builder; // для void OperationAsync() {...}
            public AsyncTaskMethodBuilder builder;   // для Task OperationAsync() {...}
            public MyClass outer;
            public int state;

            TaskAwaiter awaiter;

            void IAsyncStateMachine.MoveNext()
            {
                if (state == -1)
                {
                    awaiter = Task.Factory.StartNew(outer.Operation).GetAwaiter();

                    state = 0;

                    builder.AwaitOnCompleted(ref awaiter, ref this);
                    return;
                }

                // Задача помечается как успешно выполненная, 
                // тогда срабатывает продолжение.
                builder.SetResult();
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
            Task task = my.OperationAsync();

            task.ContinueWith(t => Console.WriteLine("\nПродолжение задачи."));

            // Delay
            Console.ReadKey();
        }
    }
}
