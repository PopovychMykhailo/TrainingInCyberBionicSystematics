using System.Collections;

namespace ArrayListDemo
{
    class Program
    {
        static void Main()
        {
            var list = new ArrayList();

            // Добавление в набор одиночных элементов используя метод Add.
            string s = "Hello";
            list.Add(s);
            list.Add("hi");
            list.Add(50);
            list.Add(new object());

            // Добавление в набор групп элементов используя метод AddRange.
            var anArray = new [] { "more", "or", "less" };
            list.AddRange(anArray);

            var anotherArray = new[] { new object(), new ArrayList() };
            list.AddRange(anotherArray);

            // Вставка элементов в заданное положение используя метод Insert.
            list.Insert(3, "Hey All");

            // Вставка элементов в заданное положение используя метод InsertRange.
            var moreString = new[] { "goodnight", "see ya" };
            list.InsertRange(4, moreString);

            // Вставка элементов в заданное положение используя индексатор.
            // (!) При использовании индексатора элемент не вставляется в набор, а перезаписывается прежний объект, бывший в этом элементе.
            list[3] = "Hey All 2";

            // Удаление из набора одиночных элементов используя метод Remove.
            list.Add("Hello");
            list.Remove("Hello");
       
            // Удаление из набора одиночных элементов с заданным индексом используя метод RemoveAt.
            list.RemoveAt(0);

            // Удаление из набора, группы элементов с заданным диапазоном используя метод RemoveRange.
            list.RemoveRange(0, 4);

            // Другие методы для добавления и удаления элементов набора - Contains, IndexOf, Clear.
            string myString = "My String";

            if (list.Contains(myString))
            {
                int index = list.IndexOf(myString);
                list.RemoveAt(index);
            }
            else
            {
                list.Clear();
            }
        }
    }
}
