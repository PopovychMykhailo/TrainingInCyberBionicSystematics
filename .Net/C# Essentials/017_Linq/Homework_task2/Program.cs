using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_task2
{
    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону Console Application.
        Представьте, что вы пишите приложение для Автостанции и вам необходимо создать простую
        коллекцию автомобилей со следующими данными: марка автомобиля, модель, год выпуска, цвет. А
        также вторую коллекцию с моделью автомобиля, именем покупателя и его номером телефона.
        Используя простейший LINQ запрос, выведите на экран информацию о покупателе одного из
        автомобилей и полную характеристику приобретенной им модели.
    */


    class Auto
    {
        public string Brand { set; get; }
        public string Model { set; get; }
        public int YearProduction { set; get; }
        public string Color { set; get; }
    }

    class Transaction
    {
        public Auto Auto { init; get; }
        public string Customer { init; get; }
        public int PhoneNumber { init; get; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Auto> autos = new List<Auto>(3);
            List<Transaction> transactions = new(5);
            string requestedCustomer;


            #region Fill the arrays

            autos.Add(new Auto { Brand = "Tesla", Model = "X Plaid", YearProduction = 2022, Color = "White" });
            autos.Add(new Auto { Brand = "Jeep", Model = "Grand Cherokee", YearProduction = 2021, Color = "Yellow" });
            autos.Add(new Auto { Brand = "Citroen", Model = "C4 Picasso", YearProduction = 2020, Color = "Dark blue" });


            transactions.Add(new Transaction { Auto = autos[0], Customer = "Mykhailo", PhoneNumber = 8570 });
            transactions.Add(new Transaction { Auto = autos[1], Customer = "Alexandr", PhoneNumber = 9999 });
            transactions.Add(new Transaction { Auto = autos[0], Customer = "Larisa", PhoneNumber = 1110 });
            transactions.Add(new Transaction { Auto = autos[2], Customer = "Tymofiy", PhoneNumber = 4026 });
            transactions.Add(new Transaction { Auto = autos[1], Customer = "Mykhailo", PhoneNumber = 3369 });
            #endregion

            while (true)
            {
                Console.Write("Enter request: ");
                requestedCustomer = Console.ReadLine();

                #region Query
                var query = from transaction in transactions
                            where transaction.Customer == requestedCustomer
                            select new
                            {
                                Customer = new
                                {
                                    Name = transaction.Customer,
                                    Phone = transaction.PhoneNumber
                                },
                                Auto = transaction.Auto
                            };
                #endregion

                #region Variant 1
                /*
                var transactionInfo = query.First();

                Console.WriteLine("Result query: ");
                Console.WriteLine($"Customer: \n" +
                    $"\t Name:   {transactionInfo.Customer.Name};\n" +
                    $"\t Phone:  {transactionInfo.Customer.Phone};\n");
                Console.WriteLine(
                    $"Auto: \n" +
                    $"\t Brand:  {transactionInfo.Auto.Brand};\n" +
                    $"\t Model:  {transactionInfo.Auto.Model};\n" +
                    $"\t Y prod: {transactionInfo.Auto.YearProduction};\n" +
                    $"\t Color:  {transactionInfo.Auto.Color};\n");
                Console.WriteLine();
                */
                #endregion

                #region Variant 2

                Console.WriteLine("Result query: ");
                foreach (var item in query)
                {
                    var transactionInfo = item;

                    Console.WriteLine($"Customer: \n" +
                        $"\t Name:   {transactionInfo.Customer.Name};\n" +
                        $"\t Phone:  {transactionInfo.Customer.Phone};\n");
                    Console.WriteLine(
                        $"Auto: \n" +
                        $"\t Brand:  {transactionInfo.Auto.Brand};\n" +
                        $"\t Model:  {transactionInfo.Auto.Model};\n" +
                        $"\t Y prod: {transactionInfo.Auto.YearProduction};\n" +
                        $"\t Color:  {transactionInfo.Auto.Color};\n");
                    Console.WriteLine();
                }
                #endregion

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
