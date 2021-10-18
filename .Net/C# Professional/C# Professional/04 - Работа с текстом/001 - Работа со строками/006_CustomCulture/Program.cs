using System;
using System.Globalization;
using System.Text;

// Создание собственной (пользовательской) культуры.
// Для работы с CultureAndRegionInfoBuilder необходимо подключить библиотеку:
// C:\Windows\winsxs\msil_sysglobl_b03f5f7f11d50a3a_6.1.7600.16385_none_a96733044673a6a5\sysglobl.dll


namespace StringBasics
{
	class Program
	{
		static void Main()
		{
			Console.OutputEncoding = Encoding.Unicode;
			// Создаем свою культуру.
			var regionInfo = new RegionInfo("US");
			Console.WriteLine("Значение свойства US.IsMetric = {0}", regionInfo.IsMetric);
			Console.WriteLine(new string('-', 25));

			var builder = new CultureAndRegionInfoBuilder("ai-en-US-cbs", CultureAndRegionModifiers.None);
			builder.LoadDataFromCultureInfo(new CultureInfo("en-US"));
			builder.LoadDataFromRegionInfo(regionInfo);

			// Внести изменения.
			builder.IsMetric = true;

			try
			{
                // Создать файл LDML (в папке ...bin\Debug\ai-en-US-cbs.ldml). 
				builder.Save("ai-en-US-cbs0.ldml");

				// Зарегистрировать в системе.
				builder.Register();               
			}
			catch (Exception e)
			{
				Console.WriteLine("Ошибка 1: {0}", e.Message);
			}
			
			try
			{
				// Удалось ли нам создать новую культуру?
				regionInfo = new RegionInfo("ai-en-US-cbs");
				Console.WriteLine("Значение свойства ai-en-US-cbs.IsMetric = {0}.", regionInfo.IsMetric);
			}
			catch (Exception e)
			{
				Console.WriteLine("Ошибка 2: {0}", e.Message);
			}

			// Delay.
			Console.ReadKey();
		}
	}
}
