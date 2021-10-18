using System;

// Перегрузка оператора неявного преобразования типа.

// Ключевое слово implicit служит для создания оператора неявного преобразования типа.

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

        // Оператор неявного преобразования типа byte-to-Digit.
        public static implicit operator Digit(byte argument)
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

            // Неявное преобразование byte-to-Digit.
            Digit digit = variable;
            Console.WriteLine(digit);

            // Delay.
            Console.ReadKey();
        }
    }
}