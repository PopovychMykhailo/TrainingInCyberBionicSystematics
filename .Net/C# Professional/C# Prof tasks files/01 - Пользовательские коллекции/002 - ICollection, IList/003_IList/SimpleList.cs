using System;
using System.Collections;

namespace Collection
{
    class SimpleList : IList //, ICollection, IEnumerable
    {
        private readonly object[] contents = new object[8];
        private int count;

        public SimpleList()
        {
            count = 0;
        }
        
        #region IList Members

        /// <summary>
        /// Добавляет элемент в список IList.
        /// </summary>
        /// <param name="value">Элемент который требуется поместить в коллекцию.</param>
        /// <returns>Индекс элемента который помещен в коллекцию.</returns>
        public int Add(object value)
        {
            if (count < contents.Length)
            {
                contents[count] = value;
                count++;

                return (count - 1);
            }
            return -1;
        }

        // Удаляет все элементы из коллекции IList.
        public void Clear()
        {
            count = 0;
        }

        // Определяет, содержится ли указанное значение в списке IList.
        public bool Contains(object value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (contents[i] == value)
                    return true;
            }
            return false;
        }

        // Определяет индекс заданного элемента в списке IList.
        public int IndexOf(object value)
        {
            for (int i = 0; i < Count; i++)
                if (contents[i] == value)
                    return i;
            return -1;
        }

        // Вставляет элемент в коллекцию IList с заданным индексом.
        public void Insert(int index, object value)
        {
            if ((count + 1 <= contents.Length) && (index < Count) && (index >= 0))
            {
                count++;

                for (int i = Count - 1; i > index; i--)
                {
                    contents[i] = contents[i - 1];
                }
                contents[index] = value;
            }
        }

        // Получает значение, показывающее, имеет ли список IList фиксированный размер.
        public bool IsFixedSize
        {
            get { return true; }
        }

        // Получает значение, указывающее, доступна ли коллекция IList только для чтения.
        public bool IsReadOnly
        {
            get { return false; }
        }

        // Удаляет первое вхождение указанного объекта из списка IList.
        public void Remove(object value)
        {
            RemoveAt(IndexOf(value));
        }

        // Удаляет элемент IList, расположенный по указанному индексу.
        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                    contents[i] = contents[i + 1];

                count--;
            }
        }

        public object this[int index]
        {
            get
            {
                return contents[index];
            }
            set
            {
                contents[index] = value;
            }
        }

        #endregion

        #region ICollection Members

        // Копирует элементы ICollection в Array, начиная с конкретного индекса Array.
        public void CopyTo(Array array, int index)
        {
            int j = index;
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(contents[i], j);
                j++;
            }
        }

        // Возвращает число элементов, содержащихся в коллекции ICollection.
        public int Count
        {
            get { return count; }
        }

        // Получает значение, позволяющее определить, является ли доступ к коллекции ICollection синхронизированным (потокобезопасным).
        public bool IsSynchronized
        {
            get { return false; }
        }

        // Получает объект, который можно использовать для синхронизации доступа к ICollection.
        public object SyncRoot
        {
            get { return null; }
        }

        #endregion

        #region IEnumerable Members

        // Возвращает перечислитель, который выполняет итерацию по элементам коллекции.  (Реализация IEnumerable.)
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return contents[i];
            }
        }

        #endregion

        public void PrintContents()
        {
            Console.WriteLine("Список имеет емкость {0} и в настоящее время имеет {1} элементов.", contents.Length, count);
            Console.Write("Список содержит:");

            for (int i = 0; i < Count; i++)
                Console.Write(" {0}", contents[i]);

            Console.WriteLine("\n" + new string('-', 55));
        }
    }
}
