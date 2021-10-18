using System;

// Необработанное исключение в деструкторе,
// приводит к остановке его работы.

namespace DestructorException
{
    class MyClass
    {
        ~MyClass()
        {
            throw new Exception();

            Console.WriteLine("Succeeded!");
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
            CreateInstance();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Hello world!");
        }
    }
}
