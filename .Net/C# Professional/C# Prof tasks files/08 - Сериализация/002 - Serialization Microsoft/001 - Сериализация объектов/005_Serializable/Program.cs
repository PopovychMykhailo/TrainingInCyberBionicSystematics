using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializableDemo
{
    [Serializable]
    class ShoppingCarItem
    {
        public int productId;
        public decimal price;
        public int quantity;
        public decimal total;

        public ShoppingCarItem(int _productId, decimal _price, int _quantity)
        {
            productId = _productId;
            price = _price;
            quantity = _quantity;
            total = price * quantity;
        }
    }

    class Program
    {
        static void Main()
        {
            ShoppingCarItem item = new ShoppingCarItem(2534681, 50000, 5);

            // Создаем файл, в который будут сохраняться данные.
            FileStream stream = new FileStream("SerializedCar.txt", FileMode.Create);

            // Создаем объект BinaryFormatter для выполнения сериализации.
            BinaryFormatter formatter = new BinaryFormatter();

            // Используем объект BinaryFormatter для сериализации данных в файл.
            formatter.Serialize(stream, item);

            // Закрываем файл.
            stream.Close();
        }
    }
}
