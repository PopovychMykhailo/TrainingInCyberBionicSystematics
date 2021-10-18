using System;
using System.Text;

// События.

namespace Events
{
    public delegate void EventDelegate();

    public class MyClass
    {
        EventDelegate myEvent = null;

        // Реализация методов доступа add и remove для события.
        public event EventDelegate MyEvent
        {
            add { myEvent += value; }
            remove { myEvent -= value; }
        }

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

            // Подписка на событие.
            instance.MyEvent += new EventDelegate(Handler1);
            instance.MyEvent += new EventDelegate(Handler2);

            // Метод который вызывает событие.
            instance.InvokeEvent();

            Console.WriteLine(new string('-', 20));

            // Открепляем Handler2().
            instance.MyEvent -= new EventDelegate(Handler2);
            instance.InvokeEvent();

            // Delay.
            Console.ReadKey();
        }
    }
}
