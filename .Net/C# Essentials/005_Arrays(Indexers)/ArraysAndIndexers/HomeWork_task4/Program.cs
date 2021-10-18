using System;

namespace HomeWork_task4
{
    class Program
    {
        /* Technical task
         * 
         * Используя Visual Studio, создайте проект по шаблону Console Application.
            Требуется:
            Создать класс Article, содержащий следующие закрытые поля:
            • название товара;
            • название магазина, в котором продается товар;
            • стоимость товара в гривнах.
            Создать класс Store, содержащий закрытый массив элементов типа Article.
            Обеспечить следующие возможности:
            • вывод информации о товаре по номеру с помощью индекса;
            • вывод на экран информации о товаре, название которого введено с клавиатуры, если таких товаров
            нет, выдать соответствующее сообщение;
            Написать программу, вывода на экран информацию о товаре
        */

        static void Main(string[] args)
        {
            try
            {
                Store store = new Store();

                Console.WriteLine("Avalaible products: ");
                store.ShowAll();
                Console.WriteLine("---------------------------------------------------");

                Console.WriteLine("Show conret product by number: ");
                store.ShowProduct(store[1]);
                Console.WriteLine("---------------------------------------------------");

                Console.WriteLine("Show conret product by name: ");
                store.ShowProduct(store["OnePlus 9 Pro"]);
                Console.WriteLine("---------------------------------------------------");

                Console.WriteLine("Show conret product by name: ");
                store.ShowProduct(store["OnePlus 10 Pro"]);
                Console.WriteLine("---------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"Exception: {ex.Message}");

                Console.ResetColor();
            }
        }
    }
}
