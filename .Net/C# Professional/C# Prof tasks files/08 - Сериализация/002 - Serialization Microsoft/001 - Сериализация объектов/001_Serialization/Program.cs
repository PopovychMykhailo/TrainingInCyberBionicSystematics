using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationDemo
{
    class Program
    {
        static void Main()
        {
            string data = "This must be stored in a file.";

            // Создаем файл, в который будут сохраняться данные.
            FileStream stream = new FileStream("SerializedString.txt", FileMode.Create);

            // Создаем объект BinaryFormatter для выполнения сериализации.
            BinaryFormatter formatter = new BinaryFormatter();

            // Используем объект BinaryFormatter для сериализации данных в файл.
            formatter.Serialize(stream, data);

            // Закрываем файл.
            stream.Close();
        }
    }
}
