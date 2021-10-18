using System;

// Необработанное исключение в деструкторе,
// приводит к остановке его работы.

namespace DestructorTryCatch
{
    class MyClass
    {
        ~MyClass()
        {
            try
            {
                throw new Exception("Some Exception");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Succeeded!");
            }
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
