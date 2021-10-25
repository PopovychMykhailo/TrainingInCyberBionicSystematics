using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Homework_task3
{
    /* Technical task
    
        Из файла TelephoneBook.xml (файл должен был быть создан в процессе выполнения
        дополнительного задания) выведите на экран только номера телефонов.
    */



    class Program
    {
        static void Main(string[] args)
        {
            string pathFile = "TelephoneBook.xml";

            var document = new XmlDocument();
            document.Load(pathFile);
            XmlNode root = document.DocumentElement;

            StringBuilder stringBuilder = new();

            // Find all unique tags type
            foreach (XmlNode item in root.ChildNodes)
            {
                //ListWorker.UniqueAdd(listItems, item.LocalName);

                stringBuilder.Clear();
                stringBuilder.Append(ParseXmlNode(item));

                Console.WriteLine(stringBuilder);
            }

        }

        public static string ParseXmlNode(XmlNode node)
        {
            StringBuilder stringBuilder = new();

            // Parse 'TelephoneNumber' atribute
            if (node.Attributes.Count > 0)
            {
                stringBuilder.Append($"{node.Attributes["Name"].Value + ":",-10} {node.Attributes["TelephoneNumber"].Value}");
            }

            // Parse all child nodes
            if (node.ChildNodes.Count > 0)
            {
                foreach (XmlNode item in node.ChildNodes)
                {
                    stringBuilder.Append($"\n{ParseXmlNode(item)}");
                }
            }


            return stringBuilder.ToString();
        }
    }
}
