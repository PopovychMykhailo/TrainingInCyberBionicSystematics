using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Homework_task3
{
    /* Technical task
    
        Несколькими способами создайте коллекцию, в которой можно хранить только целочисленные и
        вещественные значения, по типу «счет предприятия – доступная сумма» соответственно
    */


    
    class CompanyAccountCollection : HybridDictionary
    {
        HybridDictionary array = new();
        
        public void Add(string company, decimal account)
        {
            array.Add(company, account);
        }

        public decimal this[string company]
        {
            get
            {
                string[] companies = Array.Empty<string>();
                array.CopyTo(companies, 0);

                for (int i = 0; i < companies.Length; i++)
                {
                    if (companies[i] == company)
                        return (decimal)array[companies[i]];
                }

                throw new Exception("Don't find the company in the collection");
            }
        }

        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Variant 1 (I think it better variant)
            Dictionary<string, decimal> companies = new();
            companies.Add("Tesla", 3000000);
            companies.Add("Ford", 1000000);
            companies.Add("Jeep", 2000000);

            foreach (var item in companies)
                Console.WriteLine($"{item.Key,-10} -> {item.Value}");

            // Variant 2
            /*
            CompanyAccountCollection companies = new();
            companies.Add("Tesla", 3000000);
            companies.Add("Ford", 1000000);
            companies.Add("Jeep", 2000000);

            foreach (DictionaryEntry item in companies)
                Console.WriteLine($"{item.Key, -10} -> {item.Value}");
            */
        }
    }
}
