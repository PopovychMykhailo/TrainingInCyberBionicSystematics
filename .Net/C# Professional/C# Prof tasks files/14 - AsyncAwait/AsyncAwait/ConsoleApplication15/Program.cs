using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace AsyncAwait
{
    class MyClass
    {
        double Operation(object argument)
        {
            Thread.Sleep(2000);
            return (double)argument * (double)argument;
        }

        public Task<double> OperationAsync(double argument)
        {
            AsyncStateMachine stateMachine;
            stateMachine.outer = this;
            stateMachine.builder = AsyncTaskMethodBuilder<double>.Create();
            stateMachine.state = -1;
            stateMachine.argument = argument;

            stateMachine.builder.Start(ref stateMachine);

            return stateMachine.builder.Task;
        }

        struct AsyncStateMachine : IAsyncStateMachine
        {
            public AsyncTaskMethodBuilder<double> builder;
            public MyClass outer;
            public int state;
            public double argument;

            TaskAwaiter<double> awaiter;

            void IAsyncStateMachine.MoveNext()
            {
                if (state == -1)
                {
                    Func<object, double> function = outer.Operation;
                    Task<double> task = Task<double>.Factory.StartNew(function, argument);
                    awaiter = task.GetAwaiter();

                    state = 0;

                    builder.AwaitOnCompleted(ref awaiter, ref this);
                    return;
                }

                double result = awaiter.GetResult();
                builder.SetResult(result);
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
            Task<double> task = my.OperationAsync(3);

            task.ContinueWith(t => Console.WriteLine("Результат : {0}", t.Result));

            // Delay
            Console.ReadKey();
        }
    }
}
