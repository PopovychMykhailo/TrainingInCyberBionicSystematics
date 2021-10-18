using System;

// Структуры.

// В структурах нельзя инициализировать поля непосредственно в месте создания.

namespace Structure
{
    struct MyStruct
    {
        public int field;
    }

    class Program
    {
        static void Main()
        {
            // Создание экземпляра структурного типа, без вызова конструктора.
            MyStruct instance;

            instance.field = 1; // Закомментировать.

            // Попытка вывода значения неинициализированного поля приведет к ошибке.
            Console.WriteLine(instance.field);

            // Delay.
            Console.ReadKey();
        }
    }
}
