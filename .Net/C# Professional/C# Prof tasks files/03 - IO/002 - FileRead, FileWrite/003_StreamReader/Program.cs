using System;
using System.IO;

// Поиск по файлу.

// Для тестирования данного примера создайте файл: D:\test.txt

// Запишите в файл следующие строки:
// Hello 
// Andrew!
// How
// are
// you?


namespace StreamReaderDemo2
{
	class Program
	{
		static void Main()
		{
			// Подготовка файла.
			StreamReader reader = File.OpenText(@"D:\test.txt");
			
			// Последовательный обход файла.
			while (!reader.EndOfStream)
			{
				// Чтение файла построчно.
				string line = reader.ReadLine();
				
				// Если нужный текст найден, прекратить чтение.
				if (line != null && line.Contains("Andrew"))
				{
					// Обнаружив слово "Andrew", уведомить пользователя и прекратить чтение файла.
					Console.WriteLine("Found:");
					Console.WriteLine(line);
					break;
				}
			}

			//  Очистка.
			reader.Close();

			// Delay.
			Console.ReadKey();
		}
	}
}
