using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// ICollection<T> - определяет методы, используемые для управления универсальными коллекциями.

namespace Collection
{
    class UserCollection<T> : ICollection<T>
    {
        T[] elements = new T[0];

        // Добавляет элемент в интерфейс ICollection<T>.
        public void Add(T item)
        {
            var newArray = new T[elements.Length + 1]; // Создание нового массива (на 1 больше старого).
            elements.CopyTo(newArray, 0);              // Копирование старого массива в новый.
            newArray[newArray.Length - 1] = item;      // Помещение нового значения в конец массива.
            elements = newArray;                       // Замена старого массива на новый.
        }

        // Удаляет все элементы из коллекции ICollection<T>.
        public void Clear()
        {
            elements = new T[0];
        }

        // Определяет, содержит ли интерфейс ICollection<T> указанное значение.
        public bool Contains(T item)
        {
            foreach (var element in elements)
            {
                if (element.Equals(item))
                    return true;
            }

            return false; 

            ////Or we can use LINQ :)
            //elements.Contains(item);
        }

        // Копирует элементы ICollection<T> в Array, начиная с конкретного индекса Array.
        public void CopyTo(T[] array, int arrayIndex)
        {
            elements.CopyTo(array, arrayIndex);
        }

        // Получает число элементов, содержащихся в интерфейсе ICollection<T>.
        public int Count
        {
            get { return elements.Length; }
        }

        // Получает значение, указывающее, доступна ли ICollection<T> только для чтения.
        public bool IsReadOnly
        {
            get { return false; }
        }

        // Удаляет первое вхождение указанного объекта из коллекции ICollection<T>.
        public bool Remove(T item)
        {
            throw new NotImplementedException(); 
        }

        // Возвращает перечислитель, выполняющий перебор элементов в коллекции.  (Унаследовано от IEnumerable<T>.)
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>) elements).GetEnumerator();
        }

        // Возвращает перечислитель, который выполняет итерацию по элементам коллекции. (Унаследовано от IEnumerable)
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<T>).GetEnumerator();
        }
    }
}
