using System;
using System.Text;

// Получение информации о количестве элементов перечисления. Получение всех элементов перечисления и их значений

namespace Enums
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Enum.GetValues() - возвращает экземпляр System.Array, при этом каждому элементу массива 
            // будет соответствовать член указанного перечисления.

            // Помещаем в массив элементы перечисления.
            Array array = Enum.GetValues(typeof(EnumType));

            // Получаем информацию о количестве элементов в массиве.
            Console.WriteLine("Это перечисление содержит {0} членов \n", array.Length);

            // Вывод на экран всех элементов перечисления
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Имя константы: {0}, значение {0:D}", array.GetValue(i));
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
