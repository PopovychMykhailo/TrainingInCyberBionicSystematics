using System;

namespace CreateString
{
    static class Program
    {
        static void Main()
        {
            // "Hello"
            System.String s = "Hello";
            Console.WriteLine(s);
            Console.WriteLine(s.GetHashCode());
            s = s.Insert(2, "mm");
            //s[2] = 'm';
            Console.WriteLine(s);
            Console.WriteLine(s.GetHashCode());
            // "-----------------------------------------------"
            String s2 = new string('-', 20);

            //"Hello-----------------------------------------------"
            s += s2;  //s = s + s2;

            //"5"
            string s4 = 5.ToString();

            //"1 + 2 = 3"
            string s5 = String.Format("{0} + {1} = {2}", 1, 2, 1 + 2);


            // Delay
            Console.ReadKey();
        }
    }
}
