using System;

namespace HomeWork_task2
{
    /* Technical task
     *
     * Используя Visual Studio, создайте проект по шаблону Console Application.
     * Требуется:
     * Создать статический класс FindAndReplaceManager с методом void FindNext(string str) для
     * поиска по книге из примера урока 005_Delegation. При вызове этого метода, производится
     * последовательный поиск строки в книге
    */

    // Не зрозумів завдання, тому зробив як зрозумів - визивати у вказаному методі, клас Book що робить пошук

    class Book
    {
        public void FindNext(string str)
        {
            Console.WriteLine("Поиск строки : " + str);
        }
    }

    static class FindAndReplaceManager
    {
        static public void FindNext(string str)
        {
            Book book = new();

            book.FindNext(str);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FindAndReplaceManager.FindNext("123");  
        }
    }
}
