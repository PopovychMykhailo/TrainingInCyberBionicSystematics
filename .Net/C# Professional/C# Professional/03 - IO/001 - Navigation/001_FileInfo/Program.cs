using System;
using System.IO;
using System.Text;

// Навигация по файловой системе.

namespace FileInfoDemo
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Создание объекта для работы с файлом.
            FileInfo file = new FileInfo(@"C:\Windows\notepad.exe");

            // Вывод информации о файле на экран.
            if (file.Exists)
            {
                Console.WriteLine("FileName : {0}", file.Name);
                Console.WriteLine("Path     : {0}", file.FullName);
            }
            else
            {
                Console.WriteLine("Файл не существует.");
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
