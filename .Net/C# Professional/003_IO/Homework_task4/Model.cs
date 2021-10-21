using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_task4
{
    class Model
    {
        const string pathFile = "UserText.txt";
        IsolatedStorageFile userStorage;        // Our isolated directory
        IsolatedStorageFileStream fileStream;   // Our file in the directory
        StreamWriter fileWriter;                // Writer to writing data to the file
        StreamReader fileReader;                // Reader to read data from the file

        public Model()
        {
            userStorage = IsolatedStorageFile.GetUserStoreForAssembly();
        }

        public bool WriteTextToFile(string text)
        {
            fileStream = new IsolatedStorageFileStream(pathFile, FileMode.Create, FileAccess.Write, userStorage); // Open the file for write
            fileWriter = new(fileStream);           // Create the stream for writing
            fileWriter.Write(text);                 // Write all text to the file
            fileWriter.Close();                     // Close the file
            return true;                            // Return that the data recording was successful
        }

        public string ReadTextFromFile()
        {
            fileStream = new IsolatedStorageFileStream(pathFile, FileMode.OpenOrCreate, FileAccess.Read, userStorage); // Open the file for read
            fileReader = new(fileStream);           // Create the stream for reading
            string text = fileReader.ReadToEnd();   // Read all text
            fileReader.Close();                     // Close the file
            return text;                            // Return read text
        }
    }
}
