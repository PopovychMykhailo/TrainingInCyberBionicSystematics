using System;
using System.Text;
using _013_Document;

namespace Classes
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            Document document = new Document("Контракт");
            document.Body = "Тело контракта...";
            document.Footer = "Директор: Иванов И.И.";

            document.Show();

            CatShop catShop = new CatShop();
            Console.WriteLine(catShop.Cats[0].count);
            catShop.Cats[0].count -= 1;
            Console.WriteLine(catShop.Cats[0].count);
            catShop.Cats[0].count -= 3;
            Console.WriteLine(catShop.Cats[0].count);

            // Delay.
            Console.ReadKey();
        }
    }
}
