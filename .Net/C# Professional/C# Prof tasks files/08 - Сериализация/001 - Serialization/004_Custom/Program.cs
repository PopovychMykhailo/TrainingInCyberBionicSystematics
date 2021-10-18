using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

// ПОЛЬЗОВАТЕЛЬСКАЯ СЕРИАЛИЗАЦИЯ.

namespace UserSerialWork
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Car car = new Car("Mersedes-Benz", 250);
            Stream stream = File.Create("CarData.dat");
                        
            BinaryFormatter formatter = new BinaryFormatter();

            // Сериализация (Вызов метода ISerializable.GetObjectData()).
            formatter.Serialize(stream, car); 
            stream.Close();

            stream = File.OpenRead("CarData.dat");

            // Десериализация (Вызов спецконструктора).
            car = formatter.Deserialize(stream) as Car;

            Console.WriteLine(car.name + "\n" + car.speed);

            // Задержка. 
            Console.ReadKey();
        }
    }
}
