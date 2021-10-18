using System;
using System.Xml.Linq;
using System.Xml.XPath;

// Вычисление выражений с помощью XPath. (Пример: Вычисление суммы элементов)

namespace XML
{
    class Program
    {
        static void Main()
        {
            double sum = 0;

            // Создание XPath документа.
            XPathDocument document = new XPathDocument("books.xml");
            XPathNavigator navigator = document.CreateNavigator();

            // Вычисляющий запрос с предварительной компиляцией.
            XPathExpression expression = navigator.Compile("sum(ListOfBooks/Book/Price/text())");
            
            Console.WriteLine(expression.ReturnType);

            if (expression.ReturnType == XPathResultType.Number)
            {
                sum = (double)navigator.Evaluate(expression);
                Console.WriteLine(sum);
            }

            // Вычисляющий запрос без предварительной компиляции.
            // Кроме выборки производится арифметическое вычисление.
            sum = (double)navigator.Evaluate("sum(//Price/text())*10");
            Console.WriteLine(sum);

            // Delay.
            Console.ReadKey();
        }
    }
}
