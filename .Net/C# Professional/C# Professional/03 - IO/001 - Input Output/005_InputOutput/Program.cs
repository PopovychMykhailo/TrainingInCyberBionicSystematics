using System;
using System.IO;
using System.Text;

// Создание/удаление файла.

namespace InputOutput
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Создаем новый файл в корне диска D:
            var file = new FileInfo(@"D:\Test.txt");

            FileStream stream = file.Create();
   
            // Выводим основную информацию о созданном файле.            
            Console.WriteLine("Full Name   : {0}", file.FullName);
            Console.WriteLine("Attributes  : {0}", file.Attributes.ToString());
            Console.WriteLine("CreationTime: {0}", file.CreationTime);

            Console.WriteLine("Нажмите любую клавишу для удаления файла.");
            Console.ReadKey();

            // Закрываем FileStream.
            stream.Close();

            // Удаляем файл.
            file.Delete();

            Console.WriteLine("Файл успешно удален.");

            // Delay.
            Console.ReadKey();
        }
    }
}
