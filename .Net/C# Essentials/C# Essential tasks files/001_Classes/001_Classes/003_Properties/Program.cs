﻿using System;

// Классы. (Использование свойств, для доступа к закрытым полям.)

// Свойство — интерфейс доступа к полю объекта. 
// Свойства в C# — поля с логическим блоком, в котором есть ключевые слова get и set
// и являются суррогатом для замены методов доступа к полю. 
// При обращении к свойству вызывается определённый метод, который выполняет определённые операции с объектом.

namespace Classes
{
    class MyClass
    {
	    public string Field
        {
	        set // void SetField(string value)   -    Метод-мутатор - mutator   (setter)
	        ;
	        get // string GetField()             -    Метод-аксессор - accessor (getter)
	        ;
        } = null;
    }

    class Program
    {
        static void Main()
        {
            MyClass instance = new MyClass();

            instance.Field = "Hello world!";    // Метод-мутатор

            Console.WriteLine(instance.Field);  // Метод-аксессор

            // Delay.
            Console.ReadKey();
        }
    }
}