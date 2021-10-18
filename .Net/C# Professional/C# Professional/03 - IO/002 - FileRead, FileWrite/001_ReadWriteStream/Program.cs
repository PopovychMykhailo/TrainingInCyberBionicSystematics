using System;
using System.IO;
using System.Text;

// Чтение/запись в потоки (streams).

namespace ReadWriteStream
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Создаем поток для работы с памятью.
            Stream stream = new MemoryStream();

            // Добавляем в поток данные.
            Console.WriteLine("Запись в поток начата...");

            AppendToStream(stream, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 });
            Console.WriteLine("Данные успешно записаны!");

            // Считываем назад.
            Console.WriteLine("\nСодержимое потока:");
            DumpStream(stream);

            // Удаляем поток.
            stream.Close();

            // Delay.
            Console.ReadKey();
        }

        // Метод для вывода содержимого потока на экран.
        static void DumpStream(Stream stream)
        {
            // Установить курсор на начало потока.
            stream.Position = 0;

            // Обработать поток в цикле и показать его содержимое.
            while (stream.Position != stream.Length)
            {
                Console.WriteLine("{0:x3}", stream.ReadByte());
            }
        }

        // Метод для добавления данных в поток.
        static void AppendToStream(Stream stream, byte[] data)
        {
            // Установить курсор в конец потока.
            stream.Position = stream.Length;

            // Добавить байты.
            stream.Write(data, 0, data.Length);
        }
    }
}
