using System;

namespace _007_Structures
{
    /* Technical task
     * 
     * Создайте структуру с именем - Notebook.
     * Поля структуры: модель, производитель, цена.
     * В структуре должен быть реализован конструктор для инициализации полей и метод для вывода
     * содержимого полей на экран. 

    */

    struct Notebook
    {
        string model;
        string manufacturer;
        int price;

        public Notebook (string model, string manufacturer, int price)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Model:        {model}");
            Console.WriteLine($"Manufacturer: {manufacturer}");
            Console.WriteLine($"Price:        {price}");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Notebook notebook = new Notebook(model:"ThinkPad T14 Gen 2", manufacturer:"Lenovo ThinkPad", price: 1800);

            notebook.ShowInfo();
        }
    }
}
