using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DeSerializationDemo
{
    class Program
    {
        static void Main()
        {
            #region Serialization

            FileStream stream = new FileStream("SerializedDate.txt", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, DateTime.Now);
            stream.Close();

            #endregion

            // Открываем файл, из которого будут считываться данные.
            stream = new FileStream("SerializedDate.txt", FileMode.Open);

            // Создаем объект BinaryFormatter для выполнения десериализации.
            formatter = new BinaryFormatter();

            // Создаем объект для хранения десериализованных данных.
            DateTime previosTime = new DateTime();

            // Используем объект BinaryFormatter для десериализации данных из файла.
            previosTime = (DateTime)formatter.Deserialize(stream);

            // Закрываем файл.
            stream.Close();

            // Отображаем десериализованную строку.
            Console.WriteLine("Day: " + previosTime.DayOfWeek + ", Time: " + previosTime.TimeOfDay.ToString());
            Console.ReadKey();
        }
    }
}
