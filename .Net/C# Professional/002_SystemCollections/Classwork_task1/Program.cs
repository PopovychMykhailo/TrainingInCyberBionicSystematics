using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Classwork_task1
{
    /* Technical task
    
        Используя класс SortedList, создайте небольшую коллекцию и выведите на экран значения пар
        «ключ-значение» сначала в алфавитном порядке, а затем в обратном.
    */



    class MyComparerForInt : IComparer
    {
        public int Compare(object x, object y)
        {
            //Console.WriteLine(value1.GetType());
            int value1 = (int)x;
            int value2 = (int)y;
            
            return value2.CompareTo(value1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SortedList sortedList = new();
            sortedList.Add(7, "Seven");
            sortedList.Add(3, "Three");
            sortedList.Add(9, "Nine");
            sortedList.Add(1, "One");
            sortedList.Add(5, "Five");

            // Show SortedList
            foreach (DictionaryEntry item in sortedList)
                Console.WriteLine($"{item.Key}, {item.Value}");
            Console.WriteLine(new string('-', 20));


            SortedList newSortedList = new(new MyComparerForInt(), sortedList.Count);
            
            // Copy keys-values to new SortedList
            foreach (DictionaryEntry item in sortedList)
                newSortedList.Add(item.Key, item.Value);
            newSortedList.Add(6, "Six");
            
            // Show new SortedList
            foreach (DictionaryEntry item in newSortedList)
                Console.WriteLine($"{item.Key}, {item.Value}");
            Console.WriteLine(new string('-', 20));
        }
    }
}
