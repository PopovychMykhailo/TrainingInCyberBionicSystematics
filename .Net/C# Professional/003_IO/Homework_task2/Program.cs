using System;
using System.IO;

namespace Homework_task2
{
    /* Technical task
    
        Создайте файл, запишите в него произвольные данные и закройте файл. Затем снова откройте
        этот файл, прочитайте из него данные и выведете их на консоль.
    */


    class Program
    {
        static void Main(string[] args)
        {
            string pathFile = @"Test.txt";


            #region Write data to the file
            StreamWriter writer = new(pathFile);

            writer.WriteLine("1. String data 111");
            writer.WriteLine("2. String data 222");
            writer.WriteLine("3. String data 333");
            writer.Close();

            Console.WriteLine("Data successfully wrote!");
            Console.WriteLine();

            #endregion


            #region Read data from the file
            StreamReader reader = new(pathFile);

            Console.WriteLine("Read data from the file: ");

            // Read data while there is data in the stream
            while (reader.Peek() != -1)
                Console.WriteLine(reader.ReadLine());
            reader.Close();

            Console.WriteLine("All data read successfully!");
            
            #endregion
        }
    }
}
