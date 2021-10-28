using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Homework_task3
{
    /* Technical task
    
        Создайте новое приложение, в котором выполните десериализацию объекта из предыдущего
        примера. Отобразите состояние объекта на экране
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
            string pathFile = @"D:\Learning\Programming\TrainingInCyberBionicSystematics\.Net\C# Professional\008_Serialization\Homework_task2\bin\Debug\net5.0\MyClass_status.xml";
            XmlSerializer xmlSerializer = new(typeof(MyClass));

            #region Deserialize
            StreamReader streamReader = new(pathFile);
            MyClass myClassDeserialize = xmlSerializer.Deserialize(streamReader) as MyClass;
            myClassDeserialize.Show();

            //streamWriter.Close();
            #endregion
        }
    }
}
