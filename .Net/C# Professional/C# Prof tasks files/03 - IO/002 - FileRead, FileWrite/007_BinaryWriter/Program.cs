using System;
using System.IO;

// Использование BinaryWriter.

namespace BinaryWriterDemo
{
	class Program
	{
		static void Main()
		{
			// Создаем файл.
			FileStream file = File.Create(@"D:\TEMP\test.txt");

			// Сообщаем с файлом наш БайнариРайтер.
			var writer = new BinaryWriter(file);

			// Записываем в файл разные данные.
			long number = 100;
			var bytes = new byte[] { 10, 20, 50, 100 };
			string s = "hunger";

			writer.Write(number);
			writer.Write(bytes);
			writer.Write(s);
            

			// Удаляем поток.
			writer.Close();

			// Delay.
			Console.ReadKey();
		}
	}
}
