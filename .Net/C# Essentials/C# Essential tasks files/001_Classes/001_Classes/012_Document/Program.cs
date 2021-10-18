using System;
using System.Text;

namespace Classes
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            Title title = new Title();
            title.Content = "Контракт";

            Body body = new Body();
            body.Content = "Тело контракта...";

            Footer footer = new Footer();
            footer.Content = "Директор: Иванов И.И.";

            Document document = new Document(title, body, footer);
            document.Show();

            // Delay.
            Console.ReadKey();
        }
    }
}
