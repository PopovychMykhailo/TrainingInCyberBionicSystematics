using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public static class Extensions
    {
        public static void WriteLine(this string s)
        {
            Console.WriteLine(s);
        }
    }

    class Program
    {
        private static int[] array = {1, 2, 3, 4, 5, 6, 7, 8};

        static void Main(string[] args)
        {
            var query = from element in array
                        where element%2 == 0
                        select element*2;

         

            foreach (var element in query)
            {
                Console.WriteLine(element);
            }
        }
    }
}
