using Microsoft.Extensions.Configuration;
using System;

namespace ConfigurationBasic
{
    class EnvironmentConfig
    {
        public DatabaseConfig Database {get;set;}
    }

    public class DatabaseConfig
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("settings.json")
                .Build();

            var consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), configuration["Application:ConsoleColor"]);
            Console.ForegroundColor = consoleColor;
            
            var envConfig = new EnvironmentConfig();
            configuration.GetSection("Environment").Bind(envConfig);

            Console.WriteLine($"{nameof(envConfig.Database.Name)} = {envConfig.Database.Name}");
            Console.WriteLine($"{nameof(envConfig.Database.ConnectionString)} = {envConfig.Database.ConnectionString}");

            Console.WriteLine(new string('-', 30));

            Console.WriteLine("Hello World!");

            Console.ReadLine();
        }
    }
}
