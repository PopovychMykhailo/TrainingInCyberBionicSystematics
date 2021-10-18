namespace _013_Document
{
	public class CatShop
	{
		private Cat[] cats = new Cat[5];

		public Cat[] Cats
		{
			get => cats;
			set => cats = value;
		}

		public CatShop()
		{
			cats[0] = new Cat() {weight = 5, name = "Angora", count = 6};
			cats[1] = new Cat() {weight = 5, name = "Angora"};
			cats[2] = new Cat() {weight = 5, name = "Angora"};
			cats[3] = new Cat() {weight = 5, name = "Angora"};
		}
	}


}