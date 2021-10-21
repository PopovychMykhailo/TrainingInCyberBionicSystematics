using System;
using System.IO;

namespace Classwork_task1
{
    /* Technical task
    
        Создайте на диске 100 директорий с именами от Folder_0 до Folder_99, затем удалите их
    */


    class Program
    {
        static void Main(string[] args)
        {
            // Create the folder to save 100 folders
            DirectoryInfo directory = new DirectoryInfo(@"D:\Test");
            directory = directory.CreateSubdirectory(@"Test_Net");

            if (directory.Exists)
            {
                for (int i = 0; i < 100; i++)
                {
                    directory.CreateSubdirectory($"Folder_{i}");
                }

                Console.WriteLine("100 directories successfully created!");
            }
            else
            {
                Console.WriteLine("Error created directorys!");
            }
        }
    }
}
