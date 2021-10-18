using System;
using System.Collections;

namespace UserCollection
{
    class Program
    {
        static void Main()
        {
            //Обратите внимание, что сначала вызывается конструктор, 
            //    а затем три раза вызывается метод Add() для каждого элемента в списке.
            var myIntegers = new IntList() {1, 2, 3};
            myIntegers.Add(4);

            // myIntegers.Add("5"); // Ошибка компиляции.

            foreach (object i in myIntegers)
            {
                int number = (int)i;
                Console.WriteLine(number);
            }

            // Delay.
            Console.ReadKey();
        }
    }

    class IntList : ICollection, IEnumerable
    {
        private readonly ArrayList innerList = new ArrayList();

        public void Add(int number)
        {
            innerList.Add(number);
        }

        public int this[int index]
        {
            get { return (int)innerList[index]; }
        }

        #region ICollection Members
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return innerList.Count; }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
        #endregion


        #region IEnumerable Members
        public IEnumerator GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
        #endregion
    }
}
