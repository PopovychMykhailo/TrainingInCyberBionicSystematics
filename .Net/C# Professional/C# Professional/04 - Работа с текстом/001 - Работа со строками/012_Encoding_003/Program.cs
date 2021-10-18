using System;
using System.IO;
using System.Text;

namespace StringBasics
{
	class Program
	{
		static void Main()
		{
			Console.OutputEncoding = Encoding.Unicode;
			// Создание файла в кодировке UTF7.
			string file = "file.txt";
			StreamWriter writer = new StreamWriter(file, false, Encoding.UTF7);
			writer.WriteLine("Привет Мир!");
			writer.Close();
		   
			// Считывание содержимого файла с явным указанием кодировки.
			StreamReader reader = new StreamReader(file, Encoding.UTF7);
			Console.WriteLine(reader.ReadToEnd());
			reader.Close();

			// Считывание содержимого файла без указания кодировки.
			reader = new StreamReader(file);
			Console.WriteLine(reader.ReadToEnd());
			reader.Close();

			// Задержка.
			Console.ReadKey();
		}
	}
}