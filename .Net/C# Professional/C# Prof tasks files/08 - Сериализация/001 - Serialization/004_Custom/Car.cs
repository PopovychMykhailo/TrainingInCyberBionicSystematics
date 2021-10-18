using System;
using System.Runtime.Serialization;

namespace UserSerialWork
{
	[Serializable]
	public class Car : ISerializable
	{
		public string name;
		public int speed;

		public Car(string name, int speed)
		{
			this.name = name;
			this.speed = speed;
		}

		// Специальный вариант конструктора. 
		// SerializationInfo - объект в который помещаем все пары имя-значение представляющие состояние объекта.
		// SerializationInfo - мешок со свойствами (property bag)
		private Car(SerializationInfo propertyBag, StreamingContext context)
		{
			// Значение All перечисления StreamingContextState для свойства context.State, указывает,
			// что данные могут быть переданы в любое место или получены из любого места.
			Console.WriteLine("[ctor] ContextState: {0}", context.State.ToString());

			// Из мешка со свойствами извлекаем значения свойств помещеенных ранее в методе GetObjectData()
			name = propertyBag.GetString("name");
			speed = propertyBag.GetInt32("speed");
		}


		// Метод ISerializable.GetObjectData() вызывается Formatter-ом
		void ISerializable.GetObjectData(SerializationInfo propertyBag, StreamingContext context)
		{
			// Значение All перечисления StreamingContextState свойства context.State, указывает,
			// что данные могут быть переданы в любое место или получены из любого места.
			Console.WriteLine("[GetObjectData] ContextState: {0}", context.State.ToString());

			// В мешок со свойствами добавляем два свойства и соответственно значения для них.
			propertyBag.AddValue("name", name);
			propertyBag.AddValue("speed", speed);
		}
	}
}
