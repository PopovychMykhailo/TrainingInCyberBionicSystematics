using System;
using System.Text;
using System.Threading;

// IDisposable.Dispose() - как альтернатива Деструктору.

namespace IDisposableFinalization
{
    // Реализация IDisposable.
    public class MyClass : IDisposable
    {
        // Пользователь объекта должен вызвать этот метод 
        // перед завершением работы с объектом.
        public void Dispose()
        {
            // Освобождение неуправляемых ресурсов и других содержащихся объектов
            // (Например закрытие соединения с базой данных).
            Console.WriteLine("Метод Dispose() отработал:" + this.GetHashCode());
            Thread.Sleep(2000);
        }

        public void SomeMethod()
        {
            Console.WriteLine("Some work");
        }

        // Деструктор.
        ~MyClass()
        {
            for (int i = 0; i < 10; i++)
                Console.Write(".");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            MyClass instance = new MyClass();

            try
            {
                instance.SomeMethod();
            }
            finally
            {
                if (instance is IDisposable && instance != null)
                    instance.Dispose();
            }


            Console.WriteLine(new string('_', 30));

            // При использовании конструкции using:
            // Dispose() вызывается автоматически при выходе за пределы области видимости using.
            // Если возникает исключение внутри блока using, то Dispose() гарантированно вызовется.
            // При компиляции этого кода компилятор автоматически генерирует блоки try и finally.
            using (instance = new MyClass())
            {
                instance.SomeMethod();
                throw new Exception();
            } // finally{ instance.Dispose();}

            // Задержка.
            Console.ReadKey();
        }
    }
}
