using System;

// Перегрузка оператора явного преобразования типа.

// Ключевое слово explicit служит для создания оператора явного преобразования типа.

namespace MyNamespace
{
    struct Digit
    {
        public byte value;

        // Конструктор.
        Digit(byte value)
        {
            this.value = value;
        }

        // Оператор явного преобразования типа byte-to-Digit.
        public static explicit operator Digit(byte argument)
        {
            Digit digit = new Digit(argument);
            return digit;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }

    class MainClass
    {
        static void Main()
        {
            byte variable = 1;

            // Явное преобразование byte-to-Digit.
            Digit digit = (Digit)variable; 

            Console.WriteLine(digit);

            // Delay.
            Console.ReadKey();
        }
    }
}