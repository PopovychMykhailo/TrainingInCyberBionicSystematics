using System;
using System.IO;

// Навигация по файловой системе. Вывод информации о содержимом директории.

namespace DirectoryInfoDemo
{
    class Program
    {
        static void Main()
        {
            // Выбираем директорию для отслеживания.
            DirectoryInfo dir = new DirectoryInfo(@"c:\windows");

            // Выводим имя директории на экран.
            Console.WriteLine("Directory: {0}", dir.FullName);

            // Перечисляем содержимое директории.
            foreach (FileInfo file in dir.GetFiles())
            {
                Console.WriteLine("File: {0}", file.Name);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
