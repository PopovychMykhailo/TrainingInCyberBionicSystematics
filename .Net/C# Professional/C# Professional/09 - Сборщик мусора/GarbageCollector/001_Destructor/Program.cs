using System;

namespace Destructor
{
    class MyClass : Object
    {
        // Destructor (Метод Finalize)
        ~MyClass()
        {
            Console.WriteLine("Hello from Destructor!");

            // Например: Закрыть соединение с Базой Данных.
        }
    }

    class Program
    {
        static void Main()
        {
            MyClass my = new MyClass();
            // Деструктор невозможно вызвать вручную.
            // Вызывается автоматически сборщиком мусора.
            // my.~MyClass();
        }
    }
}
