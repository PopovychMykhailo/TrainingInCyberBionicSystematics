using System;
using System.Xml;

// Запись пространства имен и префиксов в XML файл.

namespace XML
{
    class Program
    {
        static void Main()
        {
            XmlTextWriter xmlWriter = new XmlTextWriter("books.xml", null);

            xmlWriter.WriteStartDocument();
            // Запишет <ListOfBooks>
            xmlWriter.WriteStartElement("ListOfBooks", null);
            // Запишет <ListOfBooks xmlns="http://localhost/test">
            xmlWriter.WriteStartElement("ListOfBooks", "http://localhost/test");
            // Запишет  <prefix:ListOfBooks xmlns:prefix="http://localhost/test" />
            xmlWriter.WriteStartElement("prefix", "ListOfBooks", "http://localhost/test");      

            xmlWriter.Close();

            // Delay.
            Console.ReadKey();
        }
    }
}
