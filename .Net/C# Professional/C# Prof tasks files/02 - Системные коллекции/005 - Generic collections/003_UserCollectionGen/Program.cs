using System;
using System.Collections;

namespace UserCollectionGen
{
    class Program
    {
        static void Main()
        {
            var myIntList = new MyList<int> {1, 2, 3};
            myIntList.Add(4);

            // myIntList.Add("5"); // Ошибка компиляции.

            foreach (var i in myIntList)
            {
                var val = i;
                Console.WriteLine(val);
            }


            var myStringList = new MyList<string> {"One", "Two"};

            // myStringList.Add(3); // Ошибка компиляции.

            // Delay.
            Console.ReadKey();
        }
    }

    class MyList<T> : ICollection
    { 
        private readonly ArrayList innerList = new ArrayList();

        // Не избавились от боксинга!
        public void Add(T val)
        {
            innerList.Add(val);
        }

        public T this[int index]
        {
            get { return (T)innerList[index]; }
        }


        #region ICollection Members
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return innerList.Capacity; }
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
