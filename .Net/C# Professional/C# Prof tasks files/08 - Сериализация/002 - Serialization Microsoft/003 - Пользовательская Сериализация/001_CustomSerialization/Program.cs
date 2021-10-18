using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CustomSerialization
{
    [Serializable]
    class ShoppingCartItem : ISerializable
    {
        public Int32 productId;
        public decimal price;
        public Int32 quantity;
        [NonSerialized]
        public decimal total;

        // Конструктор, для начального создания экземпляра.
        public ShoppingCartItem(int _productId, decimal _price, int _quantity)
        {
            productId = _productId;
            price = _price;
            quantity = _quantity;
            total = price * quantity;
        }

        // Специальный конструктор для десериализации.
        protected ShoppingCartItem(SerializationInfo propertyBag, StreamingContext context)
        {
            productId = propertyBag.GetInt32("Product Id");
            price = propertyBag.GetDecimal("Price");
            quantity = propertyBag.GetInt32("Quantity");
            total = price * quantity;
        }

        // Метод, вызываемый во время сериализации.
        public virtual void GetObjectData(SerializationInfo propertyBag, StreamingContext context)
        {
            propertyBag.AddValue("Product Id", productId);
            propertyBag.AddValue("Price", price);
            propertyBag.AddValue("Quantity", quantity);
        }

        public override string ToString()
        {
            return "id: " + productId + ": " + price + " x " + quantity + " = " + total;
        }
    }

    class Program
    {
        static void Main()
        {
            FileStream stream;
            BinaryFormatter formatter = new BinaryFormatter();
            ShoppingCartItem item = new ShoppingCartItem(22, 50000, 2);

            // Сериализация
            stream = new FileStream("SerializedItem.txt", FileMode.Create);
            formatter.Serialize(stream, item);
            stream.Close();

            // Десериализация
            stream = new FileStream("SerializedItem.txt", FileMode.Open);
            item = (ShoppingCartItem)formatter.Deserialize(stream);
            stream.Close();

            // Отображение значений полей.
            Console.WriteLine(item);

            // Delay.
            Console.ReadKey();
        }
    }
}
