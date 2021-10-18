using System;
using System.Text;

// Кодировки.

namespace StringBasics
{
    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Строка для изменения кодировок.
            string leUnicodeStr = "apple!";

            // Настройки кодировок.

            // Unicode - Получает кодировку для формата UTF-16 с прямым порядком байтов.
            Encoding leUnicode = Encoding.Unicode;

            // BigEndianUnicode - Получает кодировку для формата UTF-16 с обратным порядком байтов.
            Encoding beUnicode = Encoding.BigEndianUnicode;

            // UTF8 - Получает кодировку для формата UTF-8.
            Encoding utf8 = Encoding.UTF8;

            // Массивы байтов для хранения конвертированной строки.
            byte[] leUnicodeBytes = leUnicode.GetBytes(leUnicodeStr);						// В Unicode.
            byte[] beUnicodeBytes = Encoding.Convert(leUnicode, beUnicode, leUnicodeBytes);	// В Endian Unicode.
            byte[] utf8Bytes = Encoding.Convert(leUnicode, utf8, leUnicodeBytes);			// В UTF8.

            // Выводим содержимое массивов на экран.
            Console.WriteLine("Исходная строка: {0}\n", leUnicodeStr);


            Console.WriteLine("Байты Unicode, сначала младший:");
            var builder = new StringBuilder();
            foreach (byte b in leUnicodeBytes)
            {
                builder.Append(b).Append(":");
            }
            Console.WriteLine("{0}\n", builder);


            Console.WriteLine("Байты Unicode, сначала старший:");
            builder = new StringBuilder();
            foreach (byte b in beUnicodeBytes)
            {
                builder.Append(b).Append(":");
            }
            Console.WriteLine("{0}\n", builder);


            Console.WriteLine("Байты UTF:");
            builder = new StringBuilder();
            foreach (byte b in utf8Bytes)
            {
                builder.Append(b).Append(":");
            }
            Console.WriteLine(builder.ToString());

            // Delay.
            Console.ReadKey();
        }
    }
}