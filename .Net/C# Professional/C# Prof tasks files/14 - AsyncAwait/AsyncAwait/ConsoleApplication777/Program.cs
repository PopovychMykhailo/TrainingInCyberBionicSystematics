using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace AsyncAwaitSml
{
    class MyClass
    {
        static void Operation()
        {
            Console.WriteLine("Begin");
            Thread.Sleep(2000);
            Console.WriteLine("End");
        }

        static void Continuation()
        {
            Console.WriteLine("Continuation Begin");
            Thread.Sleep(2000);
            Console.WriteLine("Continuation End");
        }

        public void OperationAsync()
        {
            AsyncStateMachine stateMachine = new AsyncStateMachine();
            stateMachine.builder = AsyncVoidMethodBuilder.Create();
            stateMachine.builder.Start(ref stateMachine);
        }

        struct AsyncStateMachine : IAsyncStateMachine
        {
            public AsyncVoidMethodBuilder builder;
            Task task;
            TaskAwaiter taskAwaiter;

            void IAsyncStateMachine.MoveNext()
            {
                Console.WriteLine("+");
                task = new Task(Operation);                                      // 1. Создание задачи
                taskAwaiter = task.GetAwaiter();                                 // 2. Создание "ожидателя"
                taskAwaiter.OnCompleted(Continuation);                           // taskAwaiter.UnsafeOnCompleted(Continuation);
                task.Start();

                if (!taskAwaiter.IsCompleted)                                    // 3. Задача выполняется - следовательно заходим в тело if
                {
                    builder.AwaitUnsafeOnCompleted(ref taskAwaiter, ref this); 
                    //builder.AwaitOnCompleted(ref taskAwaiter, ref this); 
                    //AwaitOnCompleted(ref taskAwaiter, ref this);
                }                
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                Console.WriteLine("-");

                builder.SetStateMachine(stateMachine);
            }

            // Альтернативный метод методу builder.AwaitOnCompleted
            void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
                where TAwaiter : INotifyCompletion 
                where TStateMachine : IAsyncStateMachine
            {
                Action completionAction = (stateMachine as IAsyncStateMachine).MoveNext;
                awaiter.OnCompleted(completionAction);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();
            my.OperationAsync();

            // Delay
            Console.ReadKey();
        }
    }
}
