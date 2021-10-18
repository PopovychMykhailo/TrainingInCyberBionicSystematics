using System;
using System.Text;


namespace _005_Book
{
    class Book
    {
        class Notes
        {
            string[] arrayNotes;

            public Notes() { }

            public void AddNotes(string note)
            {
                string[] newArrayNotes = new string[arrayNotes.Length + 1];

                newArrayNotes[newArrayNotes.Length - 1] = note;

                arrayNotes = newArrayNotes;
            }

            public string[] GetAllNotes()
            {
                return arrayNotes;
            }

            public string GetNote(int index)
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

        }
    }
}
