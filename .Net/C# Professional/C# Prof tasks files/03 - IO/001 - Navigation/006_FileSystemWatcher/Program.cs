using System;
using System.IO;
/*  
 *  При наблюдении за файловой системой число изменений может превысить возможности FileSystemWatcher.
 *  Когда происходит слишком много событий, FileSystemWatcher генерирует событие Error.
 */
namespace FileSystemWatcherDemo
{
	class Program
	{
		static void Main()
		{
			// Создание наблюдателя.
            var watcher = new FileSystemWatcher(@".");
			//watcher.Path = @"D:\TESTDIR";

			// Зарегистрировать обработчики событий.
			watcher.Error += new ErrorEventHandler(WatcherError);

			// Начать мониторинг.
			watcher.EnableRaisingEvents = true;

			// Delay.
			Console.ReadKey();
		}

		// Обработчик события.
		static void WatcherError(object sender, ErrorEventArgs e)
		{
			Console.WriteLine("Error {0}", e.GetException());
		}
	}
}
