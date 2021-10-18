using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _006_JSON
{
    class Program
    {
        public enum Enum
        {
            One,
            Two,
            Three
        }

        class MyClass
        {
            private string privateField = "string1";

            public string publicField = "string2";

            public Enum enumField = Enum.Two;

            public string PublicProp { get; set; } = "string3";

            private string PrivateProp { get; set; } = "string4";

            public Part OnePart { get; set; } = new Part();

            public List<Part> ListOfParts { get; set; } = new List<Part>(){
                new Part(),
                new Part(),
                new Part()
            };


        }

        class Part
        {
            public int field1 = 1;
            protected int field2 = 2;
            private int field3 = 3;
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Mersedes auto = new Mersedes("G500", 250, Mode.Sport);
            auto.TurnOnRadio(true);
            auto.ShowMode();

            // Сериализация в строку
            Console.WriteLine(new string('-', 30));
            string json = JsonConvert.SerializeObject(auto, Formatting.Indented);
            Console.WriteLine(json);

            // Сериализация в файл
            StreamWriter file = File.CreateText(@"myAuto.json");
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, auto);
            file.Close();

            // Сериализация со строковым представлением перечислений
            Console.WriteLine(new string('-', 30));

            json = JsonConvert.SerializeObject(auto, Formatting.Indented, new StringEnumConverter());

            Console.WriteLine(json);

            // Десериализация из строки
            Console.WriteLine(new string('-', 30));

            auto = JsonConvert.DeserializeObject<Mersedes>(json);

            Console.WriteLine("Имя     : " + auto.Name);
            Console.WriteLine("Скорость: " + auto.Speed);
            auto.ShowMode();

            // Десериализация из файла
            Console.WriteLine(new string('-', 30));

            StreamReader fileReader = File.OpenText(@"myAuto.json");
            JsonSerializer serializer3 = new JsonSerializer();
            auto = (Mersedes)serializer3.Deserialize(fileReader, typeof(Mersedes));
            Console.WriteLine("Имя     : " + auto.Name);
            Console.WriteLine("Скорость: " + auto.Speed);
            auto.ShowMode();
            fileReader.Close();

            Console.ReadLine();
        }
    }
}
