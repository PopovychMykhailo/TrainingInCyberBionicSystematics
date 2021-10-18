using System;
using System.IO;

// Использование BinaryReader.

namespace BinaryReaderDemo
{
    class Program
    {
        static void Main()
        {
            // Открываем файл.
            FileStream file = File.Open(@"D:\TEMP\test.txt", FileMode.Open);

            // Сообщаем поток с файлом.
            var reader = new BinaryReader(file);

            // Читаем из файла разные данные.
            long number = reader.ReadInt64();
            byte[] bytes = reader.ReadBytes(4);
            string s = reader.ReadString();

            // Удаляем поток.
            reader.Close();

            // Выводим на экран то, что удалось прочитать.
            Console.WriteLine(number);
            foreach (byte b in bytes)
            {
                Console.Write("[{0}]", b);
            }

            Console.WriteLine();
            Console.WriteLine(s);

            // Delay.
            Console.ReadKey();
        }
    }
}
