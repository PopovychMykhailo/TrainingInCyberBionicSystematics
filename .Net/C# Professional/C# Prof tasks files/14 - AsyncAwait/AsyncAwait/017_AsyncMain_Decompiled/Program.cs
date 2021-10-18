using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace _017_AsyncMain_Decompiled
{
    class MyClass
    {
        public void Operation()
        {
            Console.WriteLine("Operation ThreadID {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Begin");
            Thread.Sleep(2000);
            Console.WriteLine("End");
        }
    }

    internal class Program
    {
        [AsyncStateMachine(typeof(Program))]
        [DebuggerStepThrough]
        private static Task Main(string[] args)
        {
            MainStateMachine stateMachine = new MainStateMachine();
            stateMachine.args = args;
            stateMachine.builder = AsyncTaskMethodBuilder.Create();
            stateMachine.state = -1;
            stateMachine.builder.Start<MainStateMachine>(ref stateMachine);
            return stateMachine.builder.Task;
        }

        [DebuggerStepThrough]
        [SpecialName]
        private static void AsyncMain(string[] args)
        {
            Program.Main(args).GetAwaiter().GetResult();
        }

        [CompilerGenerated]
        private sealed class MainStateMachine : IAsyncStateMachine
        {
            public int state;
            public AsyncTaskMethodBuilder builder;
            public string[] args;
            private MyClass my1;
            private Task task2;
            private TaskAwaiter awaiter;

            void IAsyncStateMachine.MoveNext()
            {
                int num1 = this.state;
                try
                {
                    TaskAwaiter awaiter;
                    int num2;
                    if (num1 != 0)
                    {
                        Console.WriteLine("OperationAsync (Part I) ThreadID {0}\n", (object)Thread.CurrentThread.ManagedThreadId);
                        this.my1 = new MyClass();
                        this.task2 = new Task(new Action(my1.Operation));
                        this.task2.Start();
                        awaiter = this.task2.GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.state = num2 = 0;
                            this.awaiter = awaiter;
                            MainStateMachine stateMachine = this;
                            this.builder.AwaitUnsafeOnCompleted<TaskAwaiter, MainStateMachine>(ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = this.awaiter;
                        this.awaiter = new TaskAwaiter();
                        this.state = num2 = -1;
                    }
                    awaiter.GetResult();
                    Console.WriteLine("\nOperationAsync (Part II) ThreadID {0}", (object)Thread.CurrentThread.ManagedThreadId);
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    this.state = -2;
                    this.my1 = (MyClass)null;
                    this.task2 = (Task)null;
                    this.builder.SetException(ex);
                    return;
                }
                this.state = -2;
                this.my1 = (MyClass)null;
                this.task2 = (Task)null;
                this.builder.SetResult();
            }

            [DebuggerHidden]
            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }
    }
}
