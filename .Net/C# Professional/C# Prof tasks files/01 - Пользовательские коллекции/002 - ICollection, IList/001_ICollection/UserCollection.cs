using System;
using System.Collections;

// ICollection - определяет размер, перечислители и методы синхронизации для всех нестандартных коллекций.

namespace Collection
{
    class UserCollection : ICollection
    {
        readonly object syncRoot = new object();

        readonly object[] elements = { 1, 2, 3, 4 };
        
        // Копирует элементы ICollection в Array, начиная с конкретного индекса Array.
        public void CopyTo(Array array, int userArrayIndex)
        {
            var arr = array as object[];

            if (arr == null)
                throw new ArgumentException("Expecting array to be object[]");

            for (int i = 0; i < array.Length; i++)
            {
                arr[userArrayIndex++] = elements[i];
            }
        }

        // Возвращает число элементов, содержащихся в коллекции ICollection.
        public int Count
        {
            get { return elements.Length; }
        }

        // Получает значение, позволяющее определить, является ли доступ к коллекции ICollection синхронизированным (потокобезопасным).
        public bool IsSynchronized
        {
            get { return true; }
        }

        // Получает объект, который можно использовать для синхронизации доступа к ICollection.
        public object SyncRoot
        {
            get { return syncRoot; }
        }

        // Возвращает перечислитель, который выполняет итерацию по элементам коллекции. (Унаследовано от IEnumerable.)
        public IEnumerator GetEnumerator()
        {
            return elements.GetEnumerator();
        }
    }
}
