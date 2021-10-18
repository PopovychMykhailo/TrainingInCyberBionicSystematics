using System;

// NVI - (Non-Virtual Interface)Невиртуальный Интерфейс

namespace NVI
{
	//public class Base
	//{
	//    public void DoWork()
	//    {
	//        CoreDoWork(); // private Метод (override) производного класса.
	//    }

	//    // НЕ КОМПИЛИРУЕТСЯ!!!!!!!
	//    private virtual void CoreDoWork()
	//    {
	//        Console.WriteLine("Base.DoWork()");
	//    }
	//}

	//public class Derived : Base
	//{
	//    // НЕ КОМПИЛИРУЕТСЯ!!!!!!!
	//    private override void CoreDoWork()
	//    {
	//        Console.WriteLine("Derived.DoWork()");
	//    }
	//}

	class Program
	{
		static void Main()
		{
			//Base b = new Derived();
			//b.DoWork();             // = "Derived.DoWork()"

			// Задержка.
			Console.ReadKey();
		}
	}
}
