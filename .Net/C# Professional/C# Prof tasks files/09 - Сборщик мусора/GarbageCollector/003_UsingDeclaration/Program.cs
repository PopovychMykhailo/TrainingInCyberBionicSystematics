using System;
using System.Text;
using System.Threading;

namespace _003_UsingDeclaration
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
    }

    class Program
    {
        /*
          Начиная с C# 8, допустимо использовать ключевое слово using при определении переменной.
          Оно сообщает компилятору, что метод Dispose() должен быть вызван при выходе из области видимости объявляемой переменной.
          В случае, если до выхода из области видимости объявляемой переменной возникнет исключение, метод Dispose() всё-равно будет вызван
         */

        public static void UseDisposableObject()
        {
            using MyClass instance = new MyClass();
            instance.SomeMethod();
        }

        public static void UseDisposableObjectWithException()
        {
            using MyClass instance = new MyClass();
            instance.SomeMethod();
            throw new Exception(nameof(UseDisposableObjectWithException));
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(new string('_', 30));

            UseDisposableObject();
            Console.WriteLine(new string('_', 30));
            UseDisposableObjectWithException();
            Console.WriteLine(new string('_', 30));

            Console.ReadKey();
        }
    }
}
