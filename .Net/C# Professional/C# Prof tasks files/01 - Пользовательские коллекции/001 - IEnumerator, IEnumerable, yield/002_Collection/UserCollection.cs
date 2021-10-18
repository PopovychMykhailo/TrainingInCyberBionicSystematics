using System;
using System.Collections;
using System.Collections.Generic;

// Создание простой пользовательской коллекции с использованием обобщенных интерфейсов.

namespace Collection
{
    // Класс, представляющий собой пользовательскую коллекцию.
    public class UserCollection<T> : IEnumerable<T>, IEnumerator<T>
    {
        readonly T[] elements = new T[4];

        public T this[int index]
        {
            get { return elements[index]; }
            set { elements[index] = value; }
        }

        int position = -1;

        // Реализация интерфейса IEnumerator<T>:
        bool IEnumerator.MoveNext()
        {
            if (position < elements.Length - 1)
            {
                position++;
                return true;
            }
            return false;
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get { return elements[position]; }
        }

        T IEnumerator<T>.Current
        {
            get { return elements[position]; }
        }

        // Реализация интерфейса IEnumerable<T>:
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this;
        }

        // Реализация интерфейса IDisposable:
        void IDisposable.Dispose()
        {
            ((IEnumerator)this).Reset();
        }
    }
}
