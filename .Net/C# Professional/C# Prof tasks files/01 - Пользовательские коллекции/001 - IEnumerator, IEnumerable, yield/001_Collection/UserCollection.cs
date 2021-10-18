using System;
using System.Collections;

// Создание простой пользовательской коллекции.

namespace Collection
{
    // Класс, представляющий собой пользовательскую коллекцию.
    public class UserCollection
    {
        readonly Element[] elements = new Element[4];

        public Element this[int index]
        {
            get { return elements[index]; }
            set { elements[index] = value; }
        }

        int position = -1;

        // Реализация интерфейса IEnumerator:

        public bool MoveNext()
        {
            if (position < elements.Length - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get { return elements[position]; }
        }

        // Реализация интерфейса IEnumerable:

        public UserCollection GetEnumerator()
        {
            return this;
        }
    }
}
