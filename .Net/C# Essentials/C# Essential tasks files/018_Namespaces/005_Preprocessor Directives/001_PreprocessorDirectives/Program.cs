using System;

namespace PreprocessorDirectives
{
    class Program
    {
        static void Main()
        {
            #region MyRegion

            Console.WriteLine("Hello...");

            #endregion

            // Delay.
            Console.ReadKey();
        }
    }
}
