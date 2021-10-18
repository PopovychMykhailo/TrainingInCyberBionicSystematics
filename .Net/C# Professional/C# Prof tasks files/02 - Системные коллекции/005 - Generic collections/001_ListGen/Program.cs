using System;
using System.Collections.Generic;
using System.Linq;

namespace ListGen
{
    class MyReverseComparer<T> : Comparer<T>
    {
        public override int Compare(T x, T y)
        {
            return y.GetHashCode() - x.GetHashCode();
        }
    }

    //Сортировка списка
    static class Program
    {
        static void Main()
        {
            var intList = new List<int>() { 1, 2, 3 };
            var reverseComparer = new MyReverseComparer<int>();

            int number = intList[0];
            Console.WriteLine("Original List");
            //PrintList(intList);
            intList.PrintList();

            Console.WriteLine("a. Sort(Comparision<T> comparision)");
            intList.Sort(new Comparison<int>((x, y) => y - x));

            PrintList(intList);

            Console.WriteLine("b. Sort(IComparer<T> comparer)");
            intList.Sort(reverseComparer);

            PrintList(intList);

            Console.WriteLine("c. Strict sort by using LINQ OrdeBy(Func<int,int> keySelector) extension method");
            var newList = intList.OrderBy(value => value);

            PrintList(newList);
            PrintList(intList);

            Console.ReadKey();
        }


        private static void PrintList<T>(this IEnumerable<T> intList)
        {
            foreach (T i in intList)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(new string('-', 5));
        }
    }
}
