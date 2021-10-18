using System;

// Структуры.

// Структуры могут содержать статические члены.

// Статические структуры недопустимы.

namespace Structure
{
    struct MyStruct
    {
        public static int Field
        {
            get;
            set;
        }

        public static void Show()
        {
            Console.WriteLine(Field);
        }
    }

    class Program
    {
        static void Main()
        {
            // Инициализация статических полей необязательна.
            //MyStruct.Field = 1;

            MyStruct.Show();

            // Delay.
            Console.ReadKey();
        }
    }
}
