using System;
using System.Collections;

namespace ArrayListSort
{
    class Program
    {
        static void Main()
        {
            var list = new ArrayList { 2, 3, 1 };

            list.Sort(new DescendingComparer());

            foreach (int item in list)
                Console.WriteLine(item);

            // Задержка.
            Console.ReadKey();
        }
    }

    public class DescendingComparer : IComparer
    {
        // Проверяет равенство двух объектов без учета регистра строк.
        readonly CaseInsensitiveComparer comparer = new CaseInsensitiveComparer();

        public int Compare(object x, object y)
        {
            // Для сортировки по убыванию.
            // Объекты, переданные для сравнения, меняются местами.
            int result = comparer.Compare(y, x);

            //int result = (int)x - (int)y;

            return result;
        }
    }
}
