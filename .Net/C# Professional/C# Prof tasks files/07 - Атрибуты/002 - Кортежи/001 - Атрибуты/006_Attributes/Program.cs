//#define TRIAL
#define PREMIUM

using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Attributes
{
    [Obsolete("This is an old class. Use new class instead!")] // Класс следует считать устаревшим.
    class Test
    {
        [Conditional("TRIAL")]
        public void Trial()
        {
            Console.WriteLine("Пробная версия.");
        }

        [Conditional("PREMIUM")]
        public void Release()
        {
            Console.WriteLine("Платная версия.");
        }

#if DEBUG
        public void  Initialize()
        {
            Console.WriteLine("Инициализация приложения в режиме DEBUG");
        }
#else
        private void Initialize()
        {
            Console.WriteLine("Инициализация приложения в режиме RELEASE");
        }
#endif

    }

    class Program 
    {

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Test test = new Test();

            test.Initialize();
            test.Trial();   // Вызывается только в том случае, если определен идентификатор TRIAL 
            test.Release(); // Вызывается только в том случае, если определен идентификатор RELEASE 
            Console.WriteLine(new string('-', 20));

            Type type = typeof(Test);

            MethodInfo[] methodInfo = type.GetMethods(
                BindingFlags.Public |         // Указывает, что в поиск должны быть включены открытые члены. 
                BindingFlags.NonPublic |      // Указывает, что в поиск должны быть включены члены экземпляра, не являющиеся открытыми.
                BindingFlags.Instance |       // Указывает, что в поиск должны быть включены члены экземпляра, не являющиеся открытыми.
                BindingFlags.DeclaredOnly);   // Определяет, что должны рассматриваться только члены, объявленные на уровне иерархии переданного типа. Наследуемые члены не учитываются.

            foreach (MethodInfo method in methodInfo)
            {
                Console.WriteLine(method.Name);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
