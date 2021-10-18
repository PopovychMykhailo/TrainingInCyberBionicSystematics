using System;
using System.IO;
using System.Text;

// Создание директорий.

namespace InputOutput
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            var directory = new DirectoryInfo(@"D:\TESTDIR");
            //Console.WriteLine(directory.FullName);
            // Создание в TESTDIR новых подкаталогов.
            if (directory.Exists)
            {
                // Создаем D:\TESTDIR\SUBDIR.
                directory.CreateSubdirectory("SUBDIR");

                // Создаем D:\TESTDIR\MyDir\SubMyDir.
                directory.CreateSubdirectory(@"MyDir\SubMyDir");

                Console.WriteLine("Директории созданы.");
            }
            else
            {
                Console.WriteLine("Директория с именем: {0}  не существует.", directory.FullName);
                Directory.CreateDirectory(@"D:\TESTDIR");  
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
