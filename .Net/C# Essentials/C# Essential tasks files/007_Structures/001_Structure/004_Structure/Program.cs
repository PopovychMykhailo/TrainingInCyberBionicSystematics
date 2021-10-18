using System;

// Структуры.

namespace Structure
{
    struct MyStruct
    {
        public int field;

        // Конструкторы по умолчанию нельзя задавать явно.
        //public MyStruct()
        //{
        //}

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
            MyStruct instance = new MyStruct(1);

            Console.WriteLine(instance.field);

            // Delay.
            Console.ReadKey();
        }
    }
}
