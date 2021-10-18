using System;
using System.Xml.XPath;

// Вычисление min и max с помощью XPath.

namespace XML
{
    class Program
    {
        static void Main()
        {
            // Создание XPath документа.
            XPathDocument document = new XPathDocument("books.xml");
            XPathNavigator navigator = document.CreateNavigator();


            // Вычисление последнего элемента <book> в текущем узле контекста.
            XPathExpression expression = navigator.Compile("/ListOfBooks/Book[last()]");

            XPathNodeIterator iterator = navigator.Select(expression);

            iterator.MoveNext();
            Console.WriteLine(iterator.Current);

            // Delay.
            Console.ReadKey();
        }
    }
}
