
namespace Collection
{
    // Класс элементов, которые будут входить в состав коллекции.

    public class Element
	{
		public int FieldA { get; set; }
		public int FieldB { get; set; }

		public Element(int fieldA, int fieldB)
		{
			FieldA = fieldA;
			FieldB = fieldB;
		}
	}
}
