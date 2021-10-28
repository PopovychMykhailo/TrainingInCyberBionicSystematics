using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Classwork_task1
{
    /* Technical task
    
        Создайте пользовательский тип (например, класс) и выполните сериализацию объекта этого
        типа, учитывая тот факт, что состояние объекта необходимо будет передать по сети.
    */

    [Serializable]
    public class MyClass
    {
        bool state;
        int number;
        string text;
        Dictionary<int, string> intStringPairs;


        public bool State { set => state = value; get => state; }
        public int Number { set => number = value; get => number; }
        public string Text { set => text = value; get => text; }
        public Dictionary<int, string> IntStringPairs { set => intStringPairs = value; get => intStringPairs; }


        public MyClass(bool state, int number, string text, Dictionary<int, string> intStringPairs)
        {
            this.state = state;
            this.number = number;
            this.text = text;
            this.intStringPairs = intStringPairs;
        }

        public MyClass()
        {
            state = false;
            number = -1;
            text = "defalut";
            intStringPairs = new();
        }

        public void Show()
        {
            Console.WriteLine($"{this.GetType()}: \n" +
                $"State:  {State}\n" +
                $"Number: {Number}\n" +
                $"Text:   {Text}\n" +
                $"IntStringPairs:");
            foreach (var item in IntStringPairs)
            {
                Console.WriteLine($"\t{item.Key} : {item.Value}");
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new(true, 1234567890, "Hello MyClass", new Dictionary<int, string>(5));
            myClass.IntStringPairs.Add(0, "Zero");
            myClass.IntStringPairs.Add(1, "One");
            myClass.IntStringPairs.Add(2, "Two");
            myClass.IntStringPairs.Add(3, "Three");
            myClass.IntStringPairs.Add(4, "Four");

            string pathFile = "MyClass_status.json";


            #region Serialize
            StreamWriter streamWriter = new(pathFile);
            JsonSerializer jsonSerializer = new JsonSerializer();

            jsonSerializer.Serialize(streamWriter, myClass);
            streamWriter.Close();
            #endregion

            #region Deserialize
            StreamReader streamReader = new(pathFile);
            MyClass myClassDeserialize = jsonSerializer.Deserialize(streamReader, typeof(MyClass)) as MyClass;
            myClassDeserialize.Show();

            //streamWriter.Close();
            #endregion
        }
    }
}
