using System;
using System.IO;

// Отслеживание переименования файла.

namespace FileSystemWatcherDemo
{
	class Program
	{
		static void Main()
		{
			// Создание наблюдателя.
		    var watcher = new FileSystemWatcher(@".");

			// Зарегистрировать обработчики событий.
			watcher.Renamed += new RenamedEventHandler(WatcherRenamed);

            // Начать мониторинг.
			watcher.EnableRaisingEvents = true;

			// Delay.
			Console.ReadKey();
		}

		// Обработчик события.
		static void WatcherRenamed(object sender, RenamedEventArgs e)
		{
			Console.WriteLine("Renamed from {0} to {1}", e.OldFullPath, e.FullPath);
		}
	}
}
