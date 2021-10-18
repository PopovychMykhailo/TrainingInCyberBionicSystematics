using System;
using System.Threading;

namespace DestructorThread
{
    class MyClass
    {
        ~MyClass()
        {
            Console.WriteLine("Destructor thread ID: {0}",
                Thread.CurrentThread.ManagedThreadId);
        }
    }
    class Program
    {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        static void CreateInstance()
        {
            MyClass my = new MyClass();
        }
        static void Main()
        {
            Console.WriteLine("Main thread ID: {0}",
                Thread.CurrentThread.ManagedThreadId);
            CreateInstance();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
