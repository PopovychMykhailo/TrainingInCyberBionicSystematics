using System;

// Для успешной работы метода GC.WaitForPendingFinalizers() - 
// требуется включить оптимизацию:  
// В свойствах проекта, вкладка Build -> группа General -> установить флаг Optimize Code.

namespace GCWaitFinalizers
{
    class MyClass
    {
        ~MyClass()
        {
            for (int i = 0; i < 80; i++)
                Console.Write("|");
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
            GC.WaitForPendingFinalizers(); // Установить комментарий.

            for (int i = 0; i < 80; i++)
                Console.Write(".");
        }
    }
}
