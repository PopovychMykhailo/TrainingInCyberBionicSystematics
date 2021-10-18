using System;
using System.Text;

// Тернарная условная операция.

namespace Condition
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            double quantity = 10;    // Количество единиц товара.            
            double price = 100;      // Цена за единицу товара.           
            double discount = 0.75;  // Скидка на общую стоимость - 25%.
            double cost;             // Общая стоимость.  

            // ЕСЛИ: Купили 10 единиц товара и больше. ТО: предоставить скидку в 25%. ИНАЧЕ: Скидку не предоставлять.

            cost = quantity >= 10 ? quantity * price * discount : quantity * price;

            Console.WriteLine($"Общая стоимость товара составляет: {cost} у.е.");

            // Delay.
            Console.ReadKey();
        }
    }
}
