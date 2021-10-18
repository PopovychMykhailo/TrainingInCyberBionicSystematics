using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationDemo
{
    class Program
    {
        static void Main()
        {
            // Создаем файл, в который будут сохраняться данные.
            FileStream stream = new FileStream("SerializedDate.txt", FileMode.Create);

            // Создаем объект BinaryFormatter для выполнения сериализации.
            BinaryFormatter formatter = new BinaryFormatter();

            // Используем объект BinaryFormatter для сериализации данных в файл.
            formatter.Serialize(stream, DateTime.Now);

            // Закрываем файл.
            stream.Close();
        }
    }
}
