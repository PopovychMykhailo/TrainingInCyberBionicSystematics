using System;
using System.Collections;

// Создание простой пользовательской коллекции.

namespace Collection
{
    class Program
    {
        static void Main()
        {
            var сollection = new UserCollection();

            сollection[0] = new Element(1, 2);
            сollection[1] = new Element(3, 4);
            сollection[2] = new Element(5, 6);
            сollection[3] = new Element(7, 8);

            foreach (Element element in сollection)
            {
                Console.WriteLine("{0}, {1}", element.FieldA, element.FieldB);
            }

            Console.WriteLine(new string('-', 5));

            foreach (Element element in сollection)
            {
                Console.WriteLine("{0}, {1}", element.FieldA, element.FieldB);
            }

            Console.WriteLine(new string('-', 5));

            // Так работает foreach

            IEnumerator enumerator = (сollection as IEnumerable).GetEnumerator();

            while (enumerator.MoveNext())
            {
                Element element = enumerator.Current as Element;

                Console.WriteLine("{0}, {1}", element.FieldA, element.FieldB);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
