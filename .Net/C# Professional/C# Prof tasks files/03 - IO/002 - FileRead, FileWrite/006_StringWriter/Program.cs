using System;
using System.IO;

// Запись в поток.

namespace StringWriterDemo
{
	class Program
	{
		static void Main()
		{
            // StringWriter - обертка над StringBuilder
			var writer = new StringWriter();
			writer.WriteLine("Hello all ");
			writer.Write("This is a multi-line ");
			writer.WriteLine("text string.");
            
			Console.WriteLine(writer.ToString());

			// Delay.
			Console.ReadKey();
		}
	}
}
