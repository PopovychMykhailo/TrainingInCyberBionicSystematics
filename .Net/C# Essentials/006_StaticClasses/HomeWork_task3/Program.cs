using System;

namespace HomeWork_task2
{
    /*
     * Используя Visual Studio, создайте проект по шаблону Console Application.
     * Расширьте пример урока 005_Delegation, создав в классе Book, вложенный класс Notes,
     * который позволит сохранять заметки читателя.
    */

    class Book
    {
        static public class Notes
        {
            static string[] arrayNotes;

            static Notes()
            {
                arrayNotes = Array.Empty<string>();
            }

            static public void AddNotes(string note)
            {
                string[] newArrayNotes = new string[arrayNotes.Length + 1];
                for (int i = 0; i < arrayNotes.Length; i++)
                {
                    newArrayNotes[i] = arrayNotes[i];
                }

                newArrayNotes[newArrayNotes.Length - 1] = note;

                arrayNotes = newArrayNotes;
            }

            static public string[] GetAllNotes()
            {
                return arrayNotes;
            }

            static public string GetNote(int index)
            {
                return arrayNotes[index];
            }
        }

        public void FindNext(string str)
        {
            Console.WriteLine("Поиск строки : " + str);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();

            Book.Notes.AddNotes("1. Note...");
            Book.Notes.AddNotes("2. Note...");
            Book.Notes.AddNotes("3. Note...");

            Console.WriteLine($"All notes: ");
            ShowArrayString(Book.Notes.GetAllNotes());
        }

        static void ShowArrayString(string[] arrayString)
        {
            for (int i = 0; i < arrayString.Length; i++)
            {
                Console.WriteLine(arrayString[i]);
            }
        }
    }
}
