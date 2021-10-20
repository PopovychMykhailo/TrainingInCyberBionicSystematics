using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Homework_task2
{
    /* Technical task
    
        Создайте коллекцию, в которую можно добавлять покупателей и категорию приобретенной ими
        продукции. Из коллекции можно получать категории товаров, которые купил покупатель или по
        категории определить покупателей.
    */

    class StoreCollection : IEnumerable
    {
        List<Purchase> purchases = new();

        public void Add(Customer customer, Product product)
        {
            purchases.Add(new Purchase { Customer = customer, Product = product });
        }

        public List<Product> ProductsBoughtByCustomer(string nameCustomer)
        {
            List<Product> products = new();

            for (int i = 0; i < purchases.Count; i++)
            {
                if (purchases[i].Customer.Name == nameCustomer)
                    products.Add(purchases[i].Product);
            }

            return products;
        }
        public List<Customer> CustomersWhoBoughtProduct(string nameProduct)
        {
            List<Customer> customers = new();

            for (int i = 0; i < purchases.Count; i++)
            {
                if (purchases[i].Product.Name == nameProduct)
                    customers.Add(purchases[i].Customer);
            }

            return customers;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < purchases.Count; i++)
            {
                yield return purchases[i];
            }

            yield break;
        }
    }

    class Purchase
    {
        public Customer Customer { init; get; }
        public Product Product { init; get; }
    }

    class Customer
    {
        public string Name { init; get; }
    }

    class Product
    {
        public string Name { init; get; }
    }



    class Program
    {
        static void Main(string[] args)
        {
            StoreCollection storeCollection = new();
            storeCollection.Add(new Customer { Name = "Mykhailo" }, new Product { Name = "ThinkPad T14 G2" });
            storeCollection.Add(new Customer { Name = "Larissa" }, new Product { Name = "ThinkPad T470S" });
            storeCollection.Add(new Customer { Name = "Anastasia" }, new Product { Name = "ThinkPad T470" });
            storeCollection.Add(new Customer { Name = "Mykhailo" }, new Product { Name = "ThinkPad P15 G3" });
            storeCollection.Add(new Customer { Name = "Julia" }, new Product { Name = "ThinkBook 15 G3" });
            storeCollection.Add(new Customer { Name = "Timothy" }, new Product { Name = "ThinkPad T14 G2" });
            storeCollection.Add(new Customer { Name = "Mykhailo" }, new Product { Name = "ThinkPad Yoga 14 G3" });

            foreach (Purchase item in storeCollection)
                Console.WriteLine($"{item.Customer.Name + ",", -15} {item.Product.Name}");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();


            string customer = "Mykhailo";
            Console.WriteLine($"{customer} has products: ");
            foreach (Product item in storeCollection.ProductsBoughtByCustomer(customer))
                Console.WriteLine($"\t {item.Name}");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();

            string product = "ThinkPad T14 G2";
            Console.WriteLine($"The '{product}' bought customers: ");
            foreach (Customer item in storeCollection.CustomersWhoBoughtProduct(product))
                Console.WriteLine($"\t {item.Name}");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }
    }
}
