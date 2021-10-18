using System;
using System.IO;
using System.Text;

// Копирование файлов.

namespace FileInfo_Copy
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Создаем объект для работы с файлом.
            var file = new FileInfo(@"C:\Windows\notepad.exe");

            // var dir = new DirectoryInfo(".");

            // Копируем содержимое файла.
            try
            {
                file.CopyTo(@"D:\aaaa.exe");
                Console.WriteLine("Файл успешно скопирован!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
