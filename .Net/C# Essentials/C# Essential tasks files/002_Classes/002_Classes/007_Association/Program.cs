﻿using System;
using System.Text;

// Использование техники фабричных методов.

namespace Classes
{
    class Product
    {
        public Product()
        {
            Console.WriteLine("Создан экземпляр класса Product");
        }
    }

    class Factory
    {
        public Product FactoryMethod()
        {
            return new Product();
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Factory factory = new Factory();

            Product product = factory.FactoryMethod();

            // Delay.
            Console.ReadKey();
        }
    }
}
