using System;
using System.IO;
using System.Xml.Serialization;

/*
     Чтобы создать класс, который можно сериализовать в формат XML, нужно выполнить следующее:
     - объявить класс как открытый
     - объявить все члены, которые нужно сериализовать, как открытые (public)
     - создать конструктор по умолчанию (без параметров)
 */

namespace ClassSerializationXML
{
    [XmlRoot("CarItem")]
    public class ShoppingCatItem
    {
        [XmlAttribute]
        public Int32 productId;
        public decimal price;
        public Int32 quantity;
        [XmlIgnore]
        public decimal total;

        public ShoppingCatItem()
        {
        }
    }

    class Program
    {
        static void Main()
        {
            ShoppingCatItem item = new ShoppingCatItem();
            item.productId = 22;
            item.price = 50000;
            item.quantity = 2;
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
