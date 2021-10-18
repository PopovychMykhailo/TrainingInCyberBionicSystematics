using System.IO;

// Запись в файл.

namespace StreamWriterDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			// Создание файла.
			FileStream file = File.Create(@"D:\test.txt");

			// 1.
			var writer = new StreamWriter(file);
			writer.WriteLine("Hello");
			writer.Close();
		//	file.Close();

			// 2.
			writer = File.CreateText(@"F:\test.txt");
			writer.WriteLine("Hello");
			writer.Close();

			// 3.
			File.WriteAllText(@"F:\test.txt", "Hello");

			// 4.
			file = null;
			file = File.Open(@"F:\test.txt", FileMode.Open, FileAccess.Write,FileShare.Write);
			file.Close();

			// 5.
			file = File.OpenWrite(@"F:\test.txt");
			// file.Close();

			// 6. Будет исключение, так как файл занят!
			file = File.Open(@"F:\test.txt", FileMode.OpenOrCreate, FileAccess.Write,FileShare.Write);
			// file.Close();

			// Streams - необходимо закрывать!!!
		}
	}
}
