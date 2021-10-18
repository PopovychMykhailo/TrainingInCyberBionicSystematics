using System;
using System.IO;
using System.Xml.Serialization;

namespace SerializationXML
{
    class Program
    {
        static void Main()
        {
            // Создаем файл для сохранения данных
            FileStream stream = new FileStream("SerializedDate.xml", FileMode.Create);

            // Создаем объект XmlSerializer для выполнения сериализации
            XmlSerializer serializer = new XmlSerializer(typeof(DateTime));

            // Используем объект XmlSerializer для сериализации данных в файл
            serializer.Serialize(stream, DateTime.Now);

            // Закрываем файл
            stream.Close();
        }
    }
}
