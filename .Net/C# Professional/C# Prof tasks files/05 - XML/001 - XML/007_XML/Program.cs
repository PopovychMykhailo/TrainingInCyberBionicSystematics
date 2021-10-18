using System;
using System.Xml;

// Поэлементное чтение XML файла.

namespace XML
{
    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(80, 30);

            XmlTextReader reader = new XmlTextReader("books.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    reader.Read(); // Читаем содержимое узла.
                    Console.WriteLine("{0}:{1}", reader.NodeType, reader.Value);
                }
                else
                {
                    Console.WriteLine("{0}", reader.NodeType);
                }
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
