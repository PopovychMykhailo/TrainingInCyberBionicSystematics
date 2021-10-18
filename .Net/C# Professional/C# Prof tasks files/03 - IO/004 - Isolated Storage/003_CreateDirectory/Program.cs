using System;
using System.IO;
using System.IO.IsolatedStorage;

// Работа с изолированным хранилищем.
// Создание папки для хранения файла изолированного хранилища.

// C:\Documents and Settings\Alex\AppData\Local\IsolatedStorage\ino4x4ea.2uz\nz0iufxd.k20\Url.u0krxruy11fwdogzxu1s551dfdiu3uf2\AssemFiles\SomeDir

namespace IsolatedStorageFileDemo
{
    class Program
    {
        static void Main()
        {
            // Создание изолированного хранилища уровня  .Net сборки.
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();

            // Проверить существование директории.
            string[] directories = userStorage.GetDirectoryNames("SomeDir");

            if (directories.Length == 0)
            {
                userStorage.CreateDirectory("SomeDir"); // Создаем папку.
            }

            // Создание файлового потока с указанием: Директории и Имени файла, FileMode, объекта хранилища.
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(@"SomeDir\UserSettings.set", FileMode.Create, userStorage);

            // StreamWriter - запись данных в поток userStream.
            StreamWriter userWriter = new StreamWriter(userStream);
            userWriter.WriteLine("User Prefs...");
            userWriter.Close();

            // Проверить существование файла.
            string[] files = userStorage.GetFileNames(@"SomeDir\UserSettings.set");

            if (files.Length == 0)
            {
                Console.WriteLine("No data saved for this user");
            }
            else
            {
                // Прочитать данные из потока.
                userStream = new IsolatedStorageFileStream(@"SomeDir\UserSettings.set", FileMode.Open, userStorage);

                StreamReader userReader = new StreamReader(userStream);
                string contents = userReader.ReadToEnd();
                Console.WriteLine(contents);
            }

            // Задержка.
            Console.ReadKey();
        }
    }
}
