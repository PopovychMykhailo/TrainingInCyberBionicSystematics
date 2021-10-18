using System;
using System.IO;
using System.Xml.Serialization;

namespace DeSerializationXML
{
    class Program
    {
        static void Main()
        {
            #region Сериализация

            FileStream stream = new FileStream("SerializedDate.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(DateTime));
            serializer.Serialize(stream, DateTime.Now);
            stream.Close();

            #endregion

            // Открываем файл для чтения данных
            stream = new FileStream("SerializedDate.xml", FileMode.Open);

            // Создаем объект XmlSerializer для выполнения десериализации
            serializer = new XmlSerializer(typeof(DateTime));

            // Используем объект XmlSerializer для десериализации данных из файла
            DateTime previousTime = (DateTime)serializer.Deserialize(stream);

            // Закрываем файл
            stream.Close();

            // Отображаем десериализованное время
            Console.WriteLine("Day: " + previousTime.DayOfWeek + ", Time: " + previousTime.TimeOfDay);

            // Delay.
            Console.ReadKey();
        }
    }
}
