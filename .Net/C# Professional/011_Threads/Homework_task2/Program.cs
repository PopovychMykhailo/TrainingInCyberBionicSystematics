using System;
using System.Threading;

namespace Homework_task2
{
    /* Technical task 
    
        Создайте консольное приложение, которое в различных потоках сможет получить доступ к 2-м
        файлам. Считайте из этих файлов содержимое и попытайтесь записать полученную
        информацию в третий файл. Чтение/запись должны осуществляться одновременно в каждом
        из дочерних потоков. Используйте блокировку потоков для того, чтобы добиться корректной
        записи в конечный файл.
    */




    class Program
    {
        static void Main(string[] args)
        {
            string text1 = FileWorker.ReadAll("text1.txt");
            string text2 = FileWorker.ReadAll("text2.txt");

            Console.WriteLine($"1-th text: \"{text1}\"");
            Console.WriteLine($"2-th text: \"{text2}\"");

            FileWorker.Clear("text3.txt");
            FileWorker.Write("text3.txt", text1);
            FileWorker.Write("text3.txt", text2);
            
            Console.WriteLine($"\nWrote info:\n" +
                $"{FileWorker.ReadAll("text3.txt")}");
        }
    }
}
