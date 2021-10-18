using System;
using System.Xml;

// Чтение атрибутов.

namespace XML
{
    class Program
    {
        static void Main()
        {
            var reader = new XmlTextReader("books.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    // Проверка на тип узла необходима, иначе будут найдены не только открывающие элементы (XmlNodeType.Element),
                    // но и закрывающие (XmlNodeType.EndElement).
                    if (reader.Name.Equals("Title"))   // Закомментировать и выполнить.
                    {
                        Console.WriteLine("|{0}|", reader.GetAttribute("FontSize"));
                    }
                }
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
