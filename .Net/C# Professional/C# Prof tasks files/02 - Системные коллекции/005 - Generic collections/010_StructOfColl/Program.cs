using System;
using System.Collections.Generic;
using System.Collections;

namespace StructOfColl
{
    class Program
    {
        static void Main()
        {
            var stringList = new List<string> {"Hello", "world"};

            // List<T> - поддерживает необобщенный интерфейс IList
            var theList = (IList)stringList;

            //Обращение к необобщенному индексатору
            //int firstItem = (Int32)theList[0];

            var typeSafeList = (IList<string>)stringList;
            string firstString = typeSafeList[0];

            List<string>.Enumerator e = stringList.GetEnumerator();

            while (e.MoveNext())
            {
                // Обращение к текущему элементу, обеспечивающее контроль типов
                string s = e.Current;
                Console.WriteLine(s);
            }

            Console.WriteLine(new string('-', 40));

            stringList.Sort(new MyComparer<string>());

            // Вызываем List<T>.Enumerator GetEnumerator
            foreach (string s in stringList)
            {
                Console.WriteLine(s.GetHashCode());
            }

            // Вызываем IEnumerable<T> GetEnumerator
            foreach (string s in (IEnumerable<string>)stringList)
            {
                Console.WriteLine(s);
            }
    
            //Осторожно! Изменяемая структура!
            var stringListItems = new { ItemsEnumerator = (stringList).GetEnumerator() };

            while (stringListItems.ItemsEnumerator.MoveNext())
            {
                Console.WriteLine(stringListItems.ItemsEnumerator.Current);
            }


            // Delay.
            Console.ReadKey();
        }

        class MyComparer<T> : Comparer<T>
        {
            public override int Compare(T x, T y)
            {
                return x.GetHashCode() - y.GetHashCode();
            }
        }
    }
}
