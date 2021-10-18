using System;

// dynamic - boxing.

namespace Dynamic
{
	class Program
	{
		static void Main()
		{
			dynamic dyn = 42;
			object obj = (object)42;

			dyn++;
			
			// obj++;
			obj = (int)obj + 1;

			Console.WriteLine("dyn = {0}, obj = {1}", dyn, obj);

			// Delay.
			Console.ReadKey();
		}
	}
}
