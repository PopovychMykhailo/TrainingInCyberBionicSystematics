using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Homework_task2
{
    /* Technical task
    
        Создайте класс, поддерживающий сериализацию. Выполните сериализацию объекта этого
        класса в формате XML. Сначала используйте формат по умолчанию, а затем измените его
        таким образом, чтобы значения полей сохранились в виде атрибутов элементов XML.
    */

    [Serializable, XmlRoot("MyClass")]
    public class MyClass
    {
        bool state;
        int number;
        string text;
        Dictionary<int, string> dictionaryPairs;
        List<KeyValuePair<int, string>> listPairs;

        [XmlAttribute]
        public bool State { set => state = value; get => state; }
        [XmlAttribute]
        public int Number { set => number = value; get => number; }
        [XmlAttribute]
        public string Text { set => text = value; get => text; }
        [XmlIgnore]
        public Dictionary<int, string> DictionaryPairs { set => dictionaryPairs = value; get => dictionaryPairs; }
        [XmlIgnore]
        public List<KeyValuePair<int, string>> ListPairs { set => listPairs = value; get => listPairs; }

        public MyClass(bool state, int number, string text, Dictionary<int, string> dictionaryPairs, List<KeyValuePair<int, string>> listPairs)
        {
            this.state = state;
            this.number = number;
            this.text = text;
            this.dictionaryPairs = dictionaryPairs;
            this.listPairs = listPairs;
        }

        public MyClass()
        {
            state = false;
            number = -1;
            text = "defalut";
            dictionaryPairs = new();
            listPairs = new();
        }

        public void Show()
        {
            Console.WriteLine($"{this.GetType()}: \n" +
                $"State:  {State}\n" +
                $"Number: {Number}\n" +
                $"Text:   {Text}\n" +
                $"IntStringPairs:");
            foreach (var item in DictionaryPairs)
                Console.WriteLine($"\t{item.Key} : {item.Value}");

            Console.WriteLine("ListPairs: ");
            foreach (var item in listPairs)
                Console.WriteLine($"\t{item.Key} : {item.Value}");
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            MyClass myClass = new(true, 1234567890, "Hello MyClass", new Dictionary<int, string>(5), new List<KeyValuePair<int, string>>(){
                new KeyValuePair<int, string>(5, "Five"),
                new KeyValuePair<int, string>(6, "Six"),
                new KeyValuePair<int, string>(7, "Seven"),
                new KeyValuePair<int, string>(8, "Eight"),
                new KeyValuePair<int, string>(9, "Nine"),
            });
            myClass.DictionaryPairs.Add(0, "Zero");
            myClass.DictionaryPairs.Add(1, "One");
            myClass.DictionaryPairs.Add(2, "Two");
            myClass.DictionaryPairs.Add(3, "Three");
            myClass.DictionaryPairs.Add(4, "Four");

            string pathFile = "MyClass_status.xml";

            myClass.Show();
            Console.WriteLine(new string('-', 100));


            #region Serialize
            StreamWriter streamWriter = new(pathFile);
            XmlSerializer xmlSerializer = new(typeof(MyClass));

            xmlSerializer.Serialize(streamWriter, myClass);
            streamWriter.Close();
            #endregion

            #region Deserialize
            /*
            StreamReader streamReader = new(pathFile);
            MyClass myClassDeserialize = xmlSerializer.Deserialize(streamReader) as MyClass;
            myClassDeserialize.Show();

            //streamWriter.Close();
            */
            #endregion
        }
    }
}
