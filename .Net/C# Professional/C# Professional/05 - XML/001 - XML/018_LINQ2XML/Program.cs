using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LINQ2XML
{
    class Program
    {
        static void Main()
        {
           Console.SetWindowSize(80,40);

           XDocument bench = XDocument.Load("bench.xml");
            
           PrintResults("XML Raw\n",bench);
      
           XElement root = bench.Root;

            var toolboxWithNailgun =
                from toolbox in root.Elements()
                where toolbox.Elements().Any(tool => tool.Value == "Nailgun")
                select toolbox;

            foreach (var xElement in toolboxWithNailgun)
            {
                PrintResults("The toolbox with the nailgun:", xElement.Value);
            }
         
            var handTools =
                from toolbox in root.Elements()
                from tool in toolbox.Elements()
                where tool.Name == "handtool"
                select tool.Value;

            PrintResults("The hand tools in all toolboxes", handTools);


            var handTools2 =
                root.Elements("toolbox")
                    .Elements("handtool")
                    .Select(tool => tool.Value);

            PrintResults("The hand tools in all toolboxes", handTools2);

            int toolboxCount = root.Elements("toolbox").Count();
            PrintResults("Number of toolboxes",toolboxCount);
            Console.ReadKey();
        }

        private static void PrintResults(string caption, IEnumerable<string> collection)
        {
            Console.WriteLine(caption);
            foreach (string s in collection)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(new string('-', 25));
        }

        private static void PrintResults(string caption, object value)
        {
            Console.WriteLine("{0}: {1}", caption,value);
           
            Console.WriteLine(new string('-', 25));
        }
    }
} 
