using System;
using System.Text;

// События (abstract and virtual).

namespace Events
{
    public delegate void EventDelegate();

    interface IInterface
    {
        event EventDelegate MyEvent;
        void InvokeEvent();
    }

    public class BaseClass : IInterface
    {
        public virtual event EventDelegate MyEvent = null;

        public virtual void InvokeEvent()
        {
            MyEvent.Invoke();
        }
    }

    public class DerivedClass : BaseClass
    {
        public override event EventDelegate MyEvent = null;

        public override void InvokeEvent()
        {
            MyEvent.Invoke();
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
            DerivedClass instance = new DerivedClass();

            // Присоединение обработчиков событий.
            instance.MyEvent += new EventDelegate(Handler1);
            instance.MyEvent += new EventDelegate(Handler2);

            //Метод который вызывает событие.
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
