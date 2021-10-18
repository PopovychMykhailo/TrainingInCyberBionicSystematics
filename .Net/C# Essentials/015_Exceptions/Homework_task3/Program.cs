using System;

namespace Homework_task3
{
    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Требуется описать структуру с именем Price, содержащую следующие поля:
            • название товара;
            • название магазина, в котором продается товар;
            • стоимость товара в гривнах.
        Написать программу, выполняющую следующие действия:
            • ввод с клавиатуры данных в массив, состоящий из двух элементов типа Price (записи должны
                быть упорядочены в алфавитном порядке по названиям магазинов);
            • вывод на экран информации о товарах, продающихся в магазине, название которого введено с
                клавиатуры (если такого магазина нет, вывести исключение). 
    */

    struct Product : IComparable
    {
        int price;

        public string Name { set; get; }
        public string Store { set; get; }
        public int Price
        {
            set
            {
                if (value >= 0)
                    price = value;
                else
                    throw new IncorectPriceException("The price cannot be lower than zero.");
            }

            get => price;
        }

        public Product(string name, string Store, int price)
        {

            Name = name;
            this.Store = Store;
            this.price = price;
        }

        public string GetInfo()
        {
            return $"Name: {Name}.\t Store: {Store}.\t Price: {Price}";
        }

        public int CompareTo(object product)
        {
            Product _product = (Product)product;

            if (product != null)
                return this.Name.CompareTo(_product.Name);
            else
                throw new Exception("Error compare these product, the second product is null!");
        }
    }

    class IncorectPriceException : Exception
    {
        public IncorectPriceException(string message) : base("The price is not correct! " + message) { }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[5];
            string requiredStore;


            #region Fill in the array of products

            products[0] = new Product("Samsung Note 20 Ultra", "Allo", 40000);
            products[1] = new Product("IPhone 13 Pro Max", "Citrus", 50000);
            products[2] = new Product("Xiaomi Mi 11 Ultra", "Comfy", 35000);
            products[3] = new Product("OnePlus 9 Pro", "Allo", 30000);
            products[4] = new Product("Huawei P50 Pro", "Citrus", 40000);

            // Fill the array with information from the user
            //for (int i = 0; i < products.Length; i++)
            //{
            //    try
            //    {
            //        Console.WriteLine($"Fill {i} product: ");
            //        Console.Write($"Enter name:  "); products[i].Name = Console.ReadLine();
            //        Console.Write($"Enter store: "); products[i].Store = Console.ReadLine();
            //        Console.Write($"Enter price: "); products[i].Price = Convert.ToInt32(Console.ReadLine());
            //        Console.WriteLine();
            //    }
            //    catch (IncorectPriceException ex)
            //    {
            //        --i;    // Need try again to fill

            //        WriteError("Error: enter incorect price!");
            //        WriteError($"Exception message: {ex.Message}");
            //    }
            //    catch (Exception ex)
            //    {
            //        --i;    // Need try again to fill

            //        WriteError("Error: get unknown exception!");
            //        WriteError($"Exception message: {ex.Message}");
            //    }

            //}

            Array.Sort(products);
            #endregion


            #region Find products with the required work experience

            try
            {
                bool flagFoundAnyone;

                while (true)
                {
                    flagFoundAnyone = false;
                    
                    Console.Write("Enter required store: "); requiredStore = Console.ReadLine();

                    for (int i = 0; i < products.Length; i++)
                    {
                        if (products[i].Store == requiredStore)
                        {
                            flagFoundAnyone = true;
                            Console.WriteLine(products[i].GetInfo());
                        }

                    }

                    if (flagFoundAnyone == false)
                    {
                        Console.WriteLine("Not found by your criteria!");
                    }

                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                WriteError("Error: get unknown exception!");
                WriteError($"Exception message: {ex.Message}");
            }
            #endregion
        }

        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
