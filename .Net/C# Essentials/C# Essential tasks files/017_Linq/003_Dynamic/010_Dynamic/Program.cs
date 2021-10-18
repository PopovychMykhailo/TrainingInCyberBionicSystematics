using System;

// Динамические типы данных. (События) 

namespace Dynamic
{
    delegate dynamic MyDelegate(dynamic sender, dynamic e);

    class MyClass
    {
        public dynamic MyEvent = default(dynamic); // Не есть событие.
        
        public dynamic Method(dynamic sender, dynamic e)
        {
            MyEvent.Invoke(sender, e);
            return default(dynamic);
        }
    }

    class Program
    {
        static dynamic Handler(dynamic sender, dynamic e)
        {
            Console.WriteLine("sender = {0}, e = {1}", sender, e);
            return default(dynamic);
        }

        static void Main()
        {
            dynamic my = new MyClass();
            my.MyEvent += new MyDelegate(Handler);

            my.Method("user", "mouse");

            my.MyEvent.Invoke("user", "mouse");

            // Delay.
            Console.ReadKey();
        }
    }
}
