using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_task2
{
    static class FileWorker
    {
        public static string ReadAll(string filePath)
        {
            InfoForWorking infoForWorking = new InfoForWorking() { FilePath = filePath };

            Thread thread = new(new ParameterizedThreadStart(ReadAllCore)) { Name = $"Reading from {filePath}" };
            thread.Start(infoForWorking);
            thread.Join();

            return infoForWorking.Text;
        }
        static void ReadAllCore(object info)
        {
            InfoForWorking infoForWorking = info as InfoForWorking;

            // Uses filePath as a unique object, but if filePath exists, the thread may be waiting for other threads to finish working with this file.
            // I think it good idea
            lock (infoForWorking.FilePath)
            {
                StreamReader streamReader = new(File.Open(infoForWorking.FilePath, FileMode.OpenOrCreate, FileAccess.Read));
                StringBuilder @string = new();

                @string.Append(streamReader.ReadToEnd());
                //Thread.Sleep(1000);

                streamReader.Close();

                infoForWorking.Text = @string.ToString();
            }
        }

        public static void Write(string filePath, string text)
        {
            Thread thread = new(new ParameterizedThreadStart(WriteCore)) { Name = $"Writing to {filePath}" };
            thread.Start(new InfoForWorking() { FilePath = filePath, Text = text });
        }
        static void WriteCore(object info)
        {
            InfoForWorking infoForWorking = info as InfoForWorking;

            // Uses filePath as a unique object, but if filePath exists, the thread may be waiting for other threads to finish working with this file.
            // I think it good idea
            lock (infoForWorking.FilePath)
            {
                StreamWriter streamWriter = new(File.Open(infoForWorking.FilePath, FileMode.Append, FileAccess.Write));
                StringBuilder @string = new();

                streamWriter.WriteLine(infoForWorking.Text);
                //Thread.Sleep(1000);

                streamWriter.Close();
                Console.WriteLine($"Thread wrote the data successfuly");
            }
        }

        public static void Clear(string filePath)
        {
            // Create a file so that it will be empty
            StreamWriter streamWriter = new(File.Open(filePath, FileMode.Create, FileAccess.Write));
            streamWriter.Close();
        }


        class InfoForWorking
        {
            public string FilePath { set; get; }
            public string Text { set; get; }
        }
    }
}
