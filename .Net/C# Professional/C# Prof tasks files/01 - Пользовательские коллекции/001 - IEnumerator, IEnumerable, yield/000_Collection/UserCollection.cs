using System;
using System.Collections;

// Создание простой пользовательской коллекции.

namespace Collection
{
    // Класс, представляющий собой пользовательскую коллекцию.
    public class UserCollection : IEnumerable, IEnumerator
    {
        readonly Element[] elements = new Element[4];

        public Element this[int index]
        {
            get { return elements[index]; }
            set { elements[index] = value; }
        }

        int position = -1;

        // Реализация интерфейса IEnumerator:

        bool IEnumerator.MoveNext()
        {
            if (position < elements.Length - 1)
            {
                position++;
                return true;
            }
            //((IEnumerator)this).Reset();
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

        // Реализация интерфейса IEnumerable:

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }
}
