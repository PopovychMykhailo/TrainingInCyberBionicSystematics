using System;

// Воскрешение (Resurrection) из мертвых.

namespace Resurrection
{
    internal sealed class SomeType
    {
        ~SomeType()
        {
            Console.WriteLine("Finalizer {0}", Program.counter++);

            // В этом случае при вызове метода Finalize объекта SomeType ссылка на него
            // помещается в статическую переменную живого объекта (Program)  
            // и объект (SomeType) становится доступным из кода приложения. 
            // Теперь объект "воскресает", а сборщик мусора не принимает его за мусор.
            Program.Instance = this;

            if (Program.counter < 3)
                // Вызов ReRegisterForFinalize используется для повторного вызова деструктора.
                GC.ReRegisterForFinalize(this);
        }
    }
    class Program
    {
        public static SomeType Instance { get; set; }
        public static int counter;

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        static void CreateInstance()
        {
            SomeType my = new SomeType();
        }

        static void Main()
        {
            CreateInstance(); // optimize +

            GC.Collect(); // Отработает деструктор ~SomeType()

            // Delay.
            Console.ReadKey();

            GC.Collect(); 
            // Не отработает деструктор ~SomeType() так как
            // ссылка на объект держится в статическом поле и
            // объект считается доступным.

            // Delay.
            Console.ReadKey();
        }
    }
}
