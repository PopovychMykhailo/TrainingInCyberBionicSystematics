using System;
using System.IO;

// Чтение из потока.

namespace StringReaderDemo
{
    class Program
    {
        static void Main()
        {
            string s = "Hello all!" + Environment.NewLine + "This is a multi-line \n\r text string.";

            var reader = new StringReader(s);

            // Метод Peek возвращает целочисленное значение, чтобы определить, произошла ошибка или достигнут конец файла.
            // Это позволяет пользователю сначала проверить, не равно ли возвращенное значение -1, прежде чем приводить его к типу Char.
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                Console.WriteLine(line);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
