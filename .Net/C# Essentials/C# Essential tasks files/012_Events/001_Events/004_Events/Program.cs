using System;
using System.Text;

// События (abstract and virtual).

namespace Events
{
    public delegate void EventDelegate();

    interface IInterface
    {
        event EventDelegate MyEvent; // Абстрактное событие.
    }

    public class BaseClass : IInterface
    {
        EventDelegate myEvent = null;

        public virtual event EventDelegate MyEvent // Виртуальное событие.
        {
            add { myEvent += value; }
            remove { myEvent -= value; }
        }

        public void InvokeEvent()
        {
            myEvent.Invoke();
        }
    }

    public class DerivedClass : BaseClass
    {
        public override event EventDelegate MyEvent // Переопределенное событие.
        {
            add
            {
                base.MyEvent += value;
                Console.WriteLine("К событию базового класса был прикреплен обработчик - {0}", value.Method.Name);
            }
            remove
            {
                base.MyEvent -= value;
                Console.WriteLine("От события базового класса был откреплен обработчик - {0}", value.Method.Name);
            }
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
