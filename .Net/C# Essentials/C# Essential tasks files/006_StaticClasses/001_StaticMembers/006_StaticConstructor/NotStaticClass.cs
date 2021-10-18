using System;

namespace Static
{
    class NotStaticClass
    {
        // Если класс содержит статические поля, должен быть предоставлен статический конструктор,
        // который инициализирует эти поля при загрузке класса.

        private static int field;

        public static int Property
        {
            get { return field; }
            set { field = value; }
        }

        // Статический конструктор. 
        // Единственное назначение статических конструкторов - присваивать исходные значения статическим переменным.
        static NotStaticClass()
        {
            Console.WriteLine("Статический конструктор - NotStaticClass()");
            field = 1;
        }

        //Не статический конструктор
        public NotStaticClass()
        {
            Console.WriteLine("Not static constructor!");
        }

        // Статические методы могут быть перегружены.
        public static void Method()
        {
            Console.WriteLine("Статический метод, неcтатического NotStaticClass");
        }

        // Статические методы могут быть перегружены.
        public static void Method(int s)
        {
            Console.WriteLine($"Перегруженный статический метод, неcтатического NotStaticClass {s}");
        }

        // Нестатический метод.
        public void NotStaticMethod()
        {
            Console.WriteLine(field);
        }
    }
}
