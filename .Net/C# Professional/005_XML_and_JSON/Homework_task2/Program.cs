using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;
using System.IO;

namespace Homework_task2
{
    /* Technical task
    
        Создайте приложение, которое выводит на экран всю информацию об указанном .xml файле.
    */


    class ListUniqueStrings : List<string>
    {
        public List<int> ArrayNumberSimilarities;

        public ListUniqueStrings(int lenght) : base(lenght)
        {
            ArrayNumberSimilarities = new(lenght);
        }

        public ListUniqueStrings() : base()
        {
            ArrayNumberSimilarities = new();
        }

        public void UniqueAdd(string str)
        {
            // Check the list for string
            //bool existStr = Exists((itemStr) => { return itemStr == str; });
            int existStr = IndexOf(str);
            //Console.WriteLine($"Exist '{str}' in list: {existStr}");

            if (existStr < 0)
            {
                Add(str);
                ArrayNumberSimilarities.Add(1);
            }
            else
            {
                if (existStr >= 0 && existStr < ArrayNumberSimilarities.Count)
                    ++ArrayNumberSimilarities[existStr];    // Add +1 to the similarity
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string pathFile = "TelephoneBook.xml";

            #region Analyze file
            var document = new XmlDocument();
            document.Load(pathFile);
            XmlNode root = document.DocumentElement;

            ListUniqueStrings listItems = new();
            StringBuilder stringBuilder = new();

            Console.WriteLine($"Root element: {root.LocalName}\n");

            // Find all unique tags type
            foreach (XmlNode item in root.ChildNodes)
            {
                //ListWorker.UniqueAdd(listItems, item.LocalName);

                stringBuilder.Clear();
                stringBuilder.Append(ParseXmlNode(item, ""));

                listItems.UniqueAdd(stringBuilder.ToString());
            }

            // Show all unique tags type
            Console.WriteLine($"The root element has {listItems.Count} unique tags type");
            for (int i = 0; i < listItems.Count; ++i)
            {
                Console.WriteLine("{0} copies: \n{1}", listItems.ArrayNumberSimilarities[i], listItems[i]);
            }

            #endregion


            #region Show file in console
            FileStream fileStream = new(pathFile, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new(fileStream);

            Console.WriteLine(new string('-', 100));
            Console.WriteLine("XML text:\n");

            while (streamReader.Peek() > -1)
            {
                Console.WriteLine(streamReader.ReadLine());
            }

            #endregion
        }

        public static string ParseXmlNode(XmlNode node, string offsetStr)
        {
            StringBuilder stringBuilder = new();

            stringBuilder.Append(offsetStr + $"Type \"{node.Name}\": \n");

            // Parse all atributes
            if (node.Attributes.Count > 0)
            {
                stringBuilder.Append(offsetStr + "\tAttributes: ");
                foreach (XmlAttribute item in node.Attributes)
                {
                    stringBuilder.Append($"{item.Name}; ");
                }
                stringBuilder.Append('\n');
            }

            // Parse all child nodes
            if (node.ChildNodes.Count > 0)
            {
                stringBuilder.Append(offsetStr + "\tChild nodes: \n");
                foreach (XmlNode item in node.ChildNodes)
                {
                    stringBuilder.Append($"{ParseXmlNode(item, offsetStr + "\t\t")}");
                }
                //stringBuilder.Append('\n');
            }


            return stringBuilder.ToString();
        }
    }
}
