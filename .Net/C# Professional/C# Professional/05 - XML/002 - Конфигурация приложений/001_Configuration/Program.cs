using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using System.IO;
using System.Linq;

namespace ConfigurationBasic
{

    /*
     Для работы с конфигурацией приложения, необходимо установить следующие Nuget пакеты:
     "Microsoft.Extensions.Configuration" - базовая функциональность для работы с конфигурациями
     "Microsoft.Extensions.Configuration.Json" - классы JSON провайдера конфигураций, 
      которые позволяют добавить JSON файл в качестве источника конфигураций при построении объекта IConfiguration
     */

    class Program
    {
        static void Main()
        {
            var configurationBuilder = new ConfigurationBuilder();
            IConfigurationRoot configuration = configurationBuilder
                .Add(new MyFileFormatConfigurationSource("test.mysettings"))
                .AddJsonFile("test.json")
                .Build();

            Console.WriteLine(configuration.GetDebugView());
            Console.WriteLine($"key1 = {configuration["key1"]}");
            Console.WriteLine($"key10 = {configuration["key10"]}");
        }
    }

    internal class MyFileFormatConfigurationSource : IConfigurationSource
    {
        private readonly string _filePath;

        public MyFileFormatConfigurationSource(string filePath)
        {
            _filePath = filePath;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new MyFileFormatConfigurationProvider(_filePath);
        }
    }

    internal class MyFileFormatConfigurationProvider : IConfigurationProvider
    {
        private Dictionary<string, string> _data;
        private string _filePath;

        public MyFileFormatConfigurationProvider(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string parentPath)
        {
            return parentPath == null
                ? _data.Select(x=>x.Key)
                : _data.Keys.Where(x => x == parentPath);
        }

        public IChangeToken GetReloadToken()
        {
            return new ConfigurationReloadToken();
        }

        public void Load()
        {
            var fileLines = File.ReadAllLines(_filePath);
            _data = fileLines.Select(x =>
            {
                var segments = x.Split("=");
                return (key: segments[0], value: segments[1]);
            }).ToDictionary(x => x.key, x => x.value);
        }

        public void Set(string key, string value)
        {
            _data[key] = value;
        }

        public bool TryGet(string key, out string value)
        {
            return _data.TryGetValue(key, out value);
        }
    }
}
