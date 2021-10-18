using System.Collections;

// Создание простой пользовательской коллекции с использованием оператора yield.

namespace Collection
{
	// Класс, представляющий собой пользовательскую коллекцию.
	public class UserCollection<T>
	{
	    readonly T[] elements = new T[4];

		public T this[int index]
		{
			get { return elements[index]; }
			set { elements[index] = value; }
		}

		int position = -1;

		// Создаем метод Reset().
		public void Reset()
		{
			position = -1;
		}

		// Создаем метод GetEnumerator(), используем оператор yield.
		public IEnumerator GetEnumerator()
		{
            // ---------- 1-й вариант. ----------

            while (true)
            {
                if (position < elements.Length - 1)
                {
                    position++;
                    yield return elements[position];
                }
                else
                {
                    Reset();
                    yield break;
                }
            }

            // ---------- 2-й вариант. ----------

            //foreach (var element in elements)
            //{
            //    yield return element;
            //}

            // ---------- 3-й вариант. ----------

            //return elements.GetEnumerator();
        }
	}
}
