using System;
using System.IO;

// Использование MemoryStream.

namespace MemoryStreamDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			var memory = new MemoryStream();

			var writer = new StreamWriter(memory);
			writer.WriteLine("Hello");
			writer.WriteLine("GoodBye");

			// Приказать объекту-записи writer, переписать данные в поток - memory.
			// Flush() - очищает все буферы для текущего средства записи и вызывает запись всех данных буфера в основной поток.
			writer.Flush();

			// Создать файловый поток.
			FileStream file = File.Create(@"D:\test.txt");

			// Переписать содержимое потока памяти в файл целиком.
			memory.WriteTo(file);

			// Освободить ресурсы.
			writer.Close();
			file.Close();
			memory.Close();

			// Delay.
			Console.ReadKey();
		}
	}
}
