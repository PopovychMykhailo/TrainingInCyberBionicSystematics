using System.IO;
using System.IO.IsolatedStorage;

// Работа с изолированным хранилищем.

// Путь к хранилищу:
// C:\Users\[USER NAME]\AppData\Local\IsolatedStorage

namespace IsolatedStorageFileDemo
{
    class Program
    {
        static void Main()
        {
            // Создание изолированного хранилища уровня приложения. [В данном примере не используется!]
            //IsolatedStorageFile machineStorage = IsolatedStorageFile.GetMachineStoreForAssembly();

            // Создание изолированного хранилища уровня .Net сборки.
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();
            
            // Создание файлового потока с указанием: Имени файла, FileMode, объекта хранилища.
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Create, userStorage);

            // StreamWriter - запись данных в поток userStream.
            StreamWriter userWriter = new StreamWriter(userStream);
            userWriter.WriteLine("User Prefs... ");
            userWriter.Close();
        }
    }
}
