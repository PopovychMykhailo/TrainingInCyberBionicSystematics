using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace _019_AsyncLambda_Decompiled
{
    internal class Program
    {
        public static void Operation()
        {
            Console.WriteLine("Operation ThreadID {0}", (object)Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Begin");
            Thread.Sleep(2000);
            Console.WriteLine("End");
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Main ThreadID {0}", (object)Thread.CurrentThread.ManagedThreadId);
            (LambdaGeneratedClass.func ?? (LambdaGeneratedClass.func = new Func<Task>(LambdaGeneratedClass.lambdaGeneratedClassInstance.Method)))().Wait();
            Console.ReadKey();
        }

        [CompilerGenerated]
        [Serializable]
        private sealed class LambdaGeneratedClass
        {
            public static readonly LambdaGeneratedClass lambdaGeneratedClassInstance;
            public static Func<Task> func;

            static LambdaGeneratedClass()
            {
                lambdaGeneratedClassInstance = new LambdaGeneratedClass();
            }

            [AsyncStateMachine(typeof(LambdaStateMachine))]
            [DebuggerStepThrough]
            internal Task Method()
            {
                LambdaStateMachine stateMachine = new LambdaStateMachine();
                stateMachine.outer = this;
                stateMachine.builder = AsyncTaskMethodBuilder.Create();
                stateMachine.state = -1;
                stateMachine.builder.Start(ref stateMachine);
                return stateMachine.builder.Task;
            }

            private sealed class LambdaStateMachine : IAsyncStateMachine
            {
                public int state;
                public AsyncTaskMethodBuilder builder;
                public LambdaGeneratedClass outer;
                private Task operation;
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
                            Console.WriteLine("Lambda I ThreadID {0}", (object)Thread.CurrentThread.ManagedThreadId);
                            this.operation = new Task(Operation);
                            this.operation.Start();
                            awaiter = this.operation.GetAwaiter();
                            if (!awaiter.IsCompleted)
                            {
                                this.state = num2 = 0;
                                this.awaiter = awaiter;
                                LambdaStateMachine stateMachine = this;
                                this.builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
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
                        Console.WriteLine("Lambda II ThreadID {0}", (object)Thread.CurrentThread.ManagedThreadId);
                    }
                    catch (Exception ex)
                    {
                        this.state = -2;
                        this.operation = (Task)null;
                        this.builder.SetException(ex);
                        return;
                    }
                    this.state = -2;
                    this.operation = (Task)null;
                    this.builder.SetResult();
                }

                [DebuggerHidden]
                void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
                {
                }
            }
        }
    }
}