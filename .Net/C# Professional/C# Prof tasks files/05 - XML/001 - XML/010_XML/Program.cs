using System;
using System.Xml;

// Запись данных в XML файл.

namespace XML
{
    class Program
    {
        static void Main()
        {
            var xmlWriter = new XmlTextWriter("books.xml", null);

            xmlWriter.WriteStartDocument();                  // <?xml version="1.0"?>
            xmlWriter.WriteStartElement("ListOfBooks");      // <ListOfBooks>
            xmlWriter.WriteStartElement("Book");             //      <Book>
            xmlWriter.WriteString("Title-1");                //                Title-1
            xmlWriter.WriteEndElement();                     //       </Book>
            xmlWriter.WriteStartElement("Book");             //       <Book>
            xmlWriter.WriteString("Title-2");                //                 Title-2
            xmlWriter.WriteEndElement();                     //       </Book>   
            xmlWriter.WriteEndElement();                     // </ListOfBooks>

            xmlWriter.Close();

            // Delay.
            Console.ReadKey();
        }
    }
}
