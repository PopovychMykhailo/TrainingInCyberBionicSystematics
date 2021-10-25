using System;
using System.Xml;

namespace Classwork_task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var document = new XmlDocument();
            document.Load("TelephoneBook.xml");

            XmlNode root = document.DocumentElement;

            foreach (XmlNode telephone in root.ChildNodes)
            {
                if (telephone.LocalName == "Contact")
                    Console.WriteLine(
                        $"{telephone.LocalName, -10} " +
                        $"{telephone.Attributes[0].Name}: {telephone.Attributes[0].Value, -10}" +
                        $"{telephone.Attributes[1].Name}: {telephone.Attributes[1].Value}");

                else
                    Console.WriteLine($"Unknown tag: {telephone.LocalName}");
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
