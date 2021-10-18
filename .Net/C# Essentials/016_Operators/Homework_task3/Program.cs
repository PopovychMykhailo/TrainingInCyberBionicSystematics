using System;

namespace Homework_task3
{
    /* Technical task
        
        Создайте класс House c двумя полями и свойствами.
        Создайте два метода Clone() и DeepClone(), которые выполняют поверхностное и глубокое
        копирование соответственно. Реализуйте простой способ проверки
    */


    class House
    {
        public Country country;
        public City city;

        public double Area { set; get; }



        public House(Country country, City city, double area)
        {
            this.country = country;
            this.city = city;
            Area = area;
        }

        // Shallow copying
        public House Clone()
        {
            return (House)this.MemberwiseClone();
        }

        // Deep copying
        public House DeepClone()
        {
            return new(new Country(country.Name), new City(city.Name), Area);
        }

        public override string ToString()
        {
            return $"Type: {this.GetType()}; Country: {country.Name}; City: {city.Name}; Area: {Area}.";
        }
    }


    class Country
    {
        public string Name { set; get; }


        public Country(string name) { Name = name; }
    }
    class City
    {
        public string Name { set; get; }


        public City(string name) { Name = name; }
    }


    class Program
    {
        static void Main()
        {
            House house1 = new(new("Ukraine"), new("Kyiv"), 120);
            //House house2 = house1.Clone();      // Shallow copying
            House house2 = house1.DeepClone();  // Deep copying

            // Edit house2
            house2.country.Name = "Great Britan";
            house2.city.Name = "London";
            house2.Area = 60;
            

            Console.WriteLine($"House1: {house1}");
            Console.WriteLine($"House2: {house2}");
        }
    }
}
