using System;
using System.Collections;

namespace HashtableDemo
{
    class Program
    {
        static void Main()
        {
            var emailLookup = new Hashtable();

            // Метод Add принимает в качестве первого параметра ключ,
            // а в качестве второго - значение
            emailLookup.Add("sbishop@contoso.com", "Bishop, Scott");

            // Невозможно добавить элемент с уже имеющимся в хэш-таблице ключом.
            //emailLookup.Add("sbishop@contoso.com", "Bishop, Scott2");

            // Особенности использования индексаторов.

            // Использование индексатора эквивалентно вызову Add, 
            // если такого индекса не существует.
            emailLookup["s.bishop@contoso.com"] = "Bishop, Scott";

            // Если такой индекс существует, то происходит только замена значения.
            emailLookup["sbishop@contoso.com"] = "-------------";


            Console.WriteLine(emailLookup["sbishop@contoso.com"]);
            Console.WriteLine(emailLookup["s.bishop@contoso.com"]);
        }
    }
}
