using System;
using System.Text;

// События.

namespace Events
{
    public delegate void EventDelegate();

    public class MyClass
    {
        public event EventDelegate myEvent = null;

        public void InvokeEvent()
        {
            myEvent.Invoke();
        }
    }

    class Program
    {
        // Методы обработчики события.

        static private void Handler1()
        {
            Console.WriteLine("Обработчик события 1");
        }

        static private void Handler2()
        {
            Console.WriteLine("Обработчик события 2");
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            MyClass instance = new MyClass(); 

            // Присоединение обработчиков событий. (Подписка на событие)
            instance.myEvent += new EventDelegate(Handler1);
            instance.myEvent += Handler2;

            // Метод который вызывает событие.
            instance.InvokeEvent();

            Console.WriteLine(new string('-', 20));

            // Открепляем Handler2().
            instance.myEvent -= new EventDelegate(Handler2);

            instance.InvokeEvent();

            // Delay.
            Console.ReadKey();
        }
    }
}
