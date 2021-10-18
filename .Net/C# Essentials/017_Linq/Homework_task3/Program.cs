using System;

namespace Homework_task3
{
    /* Technical task
    
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Используя динамические и анонимные типы данных, создайте Англо-Русский словарь на 10 слов и
        выведите на экран его содержание.
    */




    class VocabularyWord
    {
        string Russian;
        string English;
    }


    class Program
    {
        static void Main(string[] args)
        {
            dynamic[] arrayWords = new dynamic[10];
            arrayWords[0] = new { Russian = "Солнце",   English = "Sun" };
            arrayWords[1] = new { Russian = "Слово",    English = "Word" };
            arrayWords[2] = new { Russian = "Ноутбук",  English = "Laptop" };
            arrayWords[3] = new { Russian = "Мышь",     English = "Mouse" };
            arrayWords[4] = new { Russian = "Екран",    English = "Monitor" };
            arrayWords[5] = new { Russian = "Стол",     English = "Table" };
            arrayWords[6] = new { Russian = "Стул",     English = "Chair" };
            arrayWords[7] = new { Russian = "Город",    English = "City" };
            arrayWords[8] = new { Russian = "Лес",      English = "Forest" };
            arrayWords[9] = new { Russian = "Озеро",    English = "Lake" };

            Console.WriteLine($"{"Russian", -15} {"English", -15}\n");
            foreach (dynamic item in arrayWords)
                Console.WriteLine($"{item.Russian, -15} {item.English, -15}");

        }
    }
}
