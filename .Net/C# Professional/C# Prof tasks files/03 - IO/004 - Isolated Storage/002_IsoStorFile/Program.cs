using System;
using System.IO;
using System.IO.IsolatedStorage;

// Работа с изолированным хранилищем.

namespace IsolatedStorageFileDemo
{
    class Program
    {
        static void Main()
        {
            // Создание изолированного хранилища уровня .Net сборки.
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();
           
            // Создание файлового потока с указанием: Имени файла, FileMode, объекта хранилища.
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Create, userStorage);

          //   StreamWriter - запись данных в поток userStream.
            StreamWriter userWriter = new StreamWriter(userStream);
            userWriter.WriteLine("User Prefs");
            userWriter.Close();

            // Проверить, если файл существует.
            string[] files = userStorage.GetFileNames("UserSettings.set");

            if (files.Length == 0)
            {
                Console.WriteLine("No data saved for this user");
            }
            else
            {
                // Прочитать данные из потока.
                userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Open, userStorage);

                StreamReader userReader = new StreamReader(userStream);
                string contents = userReader.ReadToEnd();
                Console.WriteLine(contents);
            }

            // Задержка.
            Console.ReadKey();
        }
    }
}
