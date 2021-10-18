using System;
using System.IO;
using System.Linq;
using System.Xml;

// Загрузка содержимого XML из файла.

// Примечание: В окне свойств для файла book.xml, 
// свойству - Copy to Output Directory, присвойте значение - Copy always.
// Это необходимо чтобы файл book.xml копировался в папку рядом с *.exe файлом.

namespace XML
{
    class Program
    {
        static void Main()
        {
            // Загрузка XML из файла.
            var document = new XmlDocument();
            document.Load("books.xml");

            // Показ содержимого XML.
            Console.WriteLine(document.InnerText);

            Console.WriteLine(new string('-', 20));

            // Показ кода XML документа.
            Console.WriteLine(document.InnerXml);

            // Delay.
            Console.ReadKey();
        }
    }
}
