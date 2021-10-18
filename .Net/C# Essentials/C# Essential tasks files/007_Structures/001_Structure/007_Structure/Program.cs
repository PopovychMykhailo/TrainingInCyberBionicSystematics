using System;

// Структуры. Конструкторы.

namespace Structure
{
    struct MyStruct
    {
        public int field;

        // Пользовательский конструктор с параметрами.
        public MyStruct(int value)
        {
            this.field = value;

            Console.WriteLine(value);
        }
    }

    class Program
    {
        static void Main()
        {
            // Создание экземпляра структурного типа без вызова конструктора.
            MyStruct instance;


            // Нельзя использовать не инициализированную переменную.
            // Так как конструктор не вызывался переменная field осталась не инициализированной.

            //Console.WriteLine(instance.field);   // Убрать комментарий.

            // Delay.
            Console.ReadKey();
        }
    }
}
