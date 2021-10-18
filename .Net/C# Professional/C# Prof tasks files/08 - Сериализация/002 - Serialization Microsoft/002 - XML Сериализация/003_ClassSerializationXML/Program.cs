using System;
using System.IO;
using System.Xml.Serialization;

/*
     Чтобы создать класс, который можно сериализовать в формат XML, нужно выполнить следующее:
     - объявить класс как открытый (public)
     - объявить все члены, которые нужно сериализовать, как открытые (public)
     - создать конструктор по умолчанию (без параметров)
 */

namespace ClassSerializationXML
{
    public class ShoppingCatItem
    {
        public Int32 productId;
        public decimal price;
        public Int32 quantity;
        public decimal total;
    }

    class Program
    {
        static void Main()
        {
            var item = new ShoppingCatItem {productId = 22, price = 50000, quantity = 2};
            item.total = item.quantity * item.price;

            // Создаем файл для сохранения данных
            FileStream stream = new FileStream("SerializedClass.xml", FileMode.Create);

            // Создаем объект XmlSerializer для выполнения сериализации
            XmlSerializer serializer = new XmlSerializer(typeof(ShoppingCatItem));

            // Используем объект XmlSerializer для сериализации данных в файл
            serializer.Serialize(stream, item);

            // Закрываем файл
            stream.Close();
        }
    }
}
