using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializableDemo
{
    [Serializable]
    class ShoppingCartItem : IDeserializationCallback
    {
        public int productId;
        public decimal price;
        public int quantity;
        [NonSerialized]
        public decimal total;

        public ShoppingCartItem(int _productId, decimal _price, int _quantity)
        {
            productId = _productId;
            price = _price;
            quantity = _quantity;
            //total = price * quantity;
        }

        void IDeserializationCallback.OnDeserialization(object sender)
        {
            // После десериализации подсчитываем общую стоимость.
            total = price * quantity;
        }
    }

    static class Program
    {
        static void Main()
        {
            var item = new ShoppingCartItem(2534681, 50000, 5);

            #region Сериализация

            var stream = new FileStream("SerializedCar.txt", FileMode.Create);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, item);
            stream.Close();

            #endregion

            #region Десериализвция

            stream = new FileStream("SerializedCar.txt", FileMode.Open);
            formatter = new BinaryFormatter();
            item = (ShoppingCartItem)formatter.Deserialize(stream);
            stream.Close();

            // Отображаем десериализованную строку.
            Console.WriteLine("Total : {0}", item.total);

            #endregion

            // Delay.
            Console.ReadKey();
        }
    }
}
