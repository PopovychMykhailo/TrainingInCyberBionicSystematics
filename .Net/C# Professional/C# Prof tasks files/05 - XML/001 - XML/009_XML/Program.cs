using System;
using System.Xml;

// Запись атрибутов.

namespace XML
{
    class Program
    {
        static void Main()
        {
            var xmlWriter = new XmlTextWriter("books.xml", null);

            xmlWriter.WriteStartDocument();                  // Заголовок XML - <?xml version="1.0"?>
            xmlWriter.WriteStartElement("ListOfBooks");      // Корневой элемент - <ListOfBooks>
            xmlWriter.WriteStartElement("Book");             // Книга 1 - <Book
            xmlWriter.WriteStartAttribute("FontSize");       // Атрибут - FontSize
            xmlWriter.WriteString("8");                      // ="8"
            xmlWriter.WriteEndAttribute();                   // >
            xmlWriter.WriteString("Title-1");                // Title-1
            xmlWriter.WriteEndElement();                     // </Book>
            xmlWriter.WriteEndElement();                     // </ListOfBooks>

            xmlWriter.Close();

            // Delay.
            Console.ReadKey();
        }
    }
}
