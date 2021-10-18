using System;

// Классы.

namespace Classes
{
    // Создаем класс с именем MyClass.
    // В теле класса создаем открытое поле типа string с именем field и метод с именем Method.

    class MyClass
    {
        public string field;

        public void Method()
        {
            Console.WriteLine(field);
        }
    }

    class Program
    {
        static void Main()
        {
	        MyClass instance1 = new MyClass();
	        MyClass instance2 = new MyClass();

            instance1.field = "Hello world!";
            instance2.field = "Vasya,Petya";

            Console.WriteLine(instance1.field);
            Console.WriteLine(instance2.field);
            instance2.field = instance1.field;

            Console.WriteLine(instance1.field);
            Console.WriteLine(instance2.field);


            instance1.Method();
            instance2.Method();

            // Delay.
            Console.ReadKey();
        }
    }
}
