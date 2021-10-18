using System;
using System.Xml;
using System.Text;

// Запись комментариев в XML файл.

namespace XML
{
    class Program
    {
        static void Main()
        {
            var xmlWriter = new XmlTextWriter("books.xml", Encoding.Unicode);

            xmlWriter.WriteStartDocument();                  // <?xml version="1.0"?>
            xmlWriter.WriteStartElement("ListOfBooks");      // <ListOfBooks>
            xmlWriter.WriteComment("Строка комментария.");
            xmlWriter.WriteEndElement();                     // </ListOfBooks>

            xmlWriter.Close();

            // Delay.
            Console.ReadKey();
        }
    }
}
