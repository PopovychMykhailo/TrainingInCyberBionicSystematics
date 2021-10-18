using System;
using System.Xml;

// Запись в XML файл со специальным форматированием.

namespace XML
{
    class Program
    {
        static void Main()
        {
            var xmlWriter = new XmlTextWriter("books.xml", null);
                                
            // Включить форматирование документа (с отступом).
            xmlWriter.Formatting = Formatting.Indented;

            // Для выделения уровня элемента использовать табуляцию.
            xmlWriter.IndentChar = '\t';

            // использовать один символ табуляции.
            xmlWriter.Indentation = 1;

            // Аналогично можно указать выравнивание с помощью четырех пробелов.
            //xmlWriter.IndentChar = ' ';
            //xmlWriter.Indentation = 4;

            // По умолчанию строки в XML файл записываются с помощью двойных кавычек.
            // Использование одиночных кавычек производится так:
            xmlWriter.QuoteChar = '\'';

            xmlWriter.WriteStartDocument(); 

            xmlWriter.WriteStartElement("ListOfBooks");
            xmlWriter.WriteStartElement("ListOfBooks", "http://localhost/test");
            xmlWriter.WriteStartElement("prefix", "ListOfBooks", "http://localhost/test");

            xmlWriter.Close();

            // Delay.
            Console.ReadKey();
        }
    }
}
