using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DeSerializationDemo
{
	class Program
	{
		static void Main()
		{
			#region Serialization

			string data = "This must be stored in a file.";
			var stream = new FileStream("SerializedString.txt", FileMode.Create);
			var formatter = new BinaryFormatter();
			formatter.Serialize(stream, data);
			stream.Close(); 

			#endregion

			// Открываем файл, из которого будут считываться данные.
			stream = new FileStream("SerializedString.txt", FileMode.Open);

			// Создаем объект BinaryFormatter для выполнения десериализации.
			formatter = new BinaryFormatter();
			
			// Создаем объект для хранения десериализованных данных.
			data = "";

			// Используем объект BinaryFormatter для десериализации данных из файла.
			data = (string)formatter.Deserialize(stream);

			// Закрываем файл.
			stream.Close();

			// Отображаем десериализованную строку.
			Console.WriteLine(data);

			// Delay.
			Console.ReadKey();
		}
	}
}
