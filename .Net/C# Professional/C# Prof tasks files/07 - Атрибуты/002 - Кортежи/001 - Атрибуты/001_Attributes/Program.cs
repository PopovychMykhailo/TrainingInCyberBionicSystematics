using System;

// Атрибуты. 

namespace AttributeWork
{
	[My("1/31/2008", Number = 1)]
	public class MyClass
	{
		[MyAttribute("2/31/2007", Number = 2)]
		public static void Method()
		{
			Console.WriteLine("MyClass.Method()\n");
		}
	}

	class Program
	{
		static void Main()
		{
			MyClass my = new MyClass();
			MyClass.Method();

			// Delay.
			Console.ReadKey();
		}
	}
}
