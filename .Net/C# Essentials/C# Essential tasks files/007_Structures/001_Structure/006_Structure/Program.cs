using System;

// Структуры. Статический конструктор.

namespace Structure
{
    struct MyStruct
    {
        public int field;

        // Статический конструктор всегда отрабатывает первым.
        static MyStruct()
        {
            Console.WriteLine("Static Constructor");
        }

        // Если в структуре имеется пользовательский конструктор, то требуется в нем инициализировать все поля.
        public MyStruct(int value)
        {
            Console.WriteLine("Constructor");
            this.field = value;
        }
    }

    class Program
    {
        static void Main()
        {
            // Создание экземпляра структурного типа, с вызовом пользовательского конструктора.
            MyStruct instance = new MyStruct { field = 0 };

            Console.WriteLine(instance.field);

            // Delay.
            Console.ReadKey();
        }
    }
}
