using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;

// СЕРИАЛИЗАЦИЯ в ДВОИЧНОМ ФОРМАТЕ.

namespace SerializableWork
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Mersedes auto = new Mersedes("G500", 250, Mode.Lux);
            auto.TurnOnRadio(true);
            auto.ShowMode();

            FileStream stream = File.Create("CarData.xml");

            // Помещаем объектный граф (для базовых типов) в поток в двоичном формате.
            SoapFormatter formatter = new SoapFormatter();

            // Cериализация.
            formatter.Serialize(stream, auto);
            stream.Close();


            stream = File.OpenRead("CarData.xml");

            // Десериализация.
            auto = formatter.Deserialize(stream) as Mersedes;

            Console.WriteLine("Имя     : " + auto.Name);
            Console.WriteLine("Скорость: " + auto.Speed);
            auto.TurnOnRadio(false);
            stream.Close();

            // Задержка.
            Console.ReadKey();
        }
    }
}
