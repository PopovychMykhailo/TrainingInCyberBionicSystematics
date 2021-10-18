using System;

// Анонимные типы.

// Анонимные типы предлагают удобный способ инкапсулирования набора свойств в один объект 
// без необходимости предварительного явного определения типа.
// Имя типа создается компилятором и недоступно на уровне исходного кода.
// Анонимные типы являются ссылочными типами, которые происходят непосредственно от класса object.
// Компилятор присваивает им имена, несмотря на то что эти имена недоступны для приложения.

namespace Anonymous
{
    class Program
    {
        static void Main()
        {
            var instance = new { Name = "Alex", Age = 27 };

            Console.WriteLine("Name = {0}, Age = {1}", instance.Name, instance.Age);

            Type type = instance.GetType();

            Console.WriteLine(type.ToString());

            // Delay.
            Console.ReadKey();
        }
    }
}
