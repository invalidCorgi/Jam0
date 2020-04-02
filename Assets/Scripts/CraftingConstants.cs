public static class CraftingConstants
{
	public enum Resource
	{
		None,
		Engine,
		Bunny,
		HamsterReel,
		Cable,
		Hammer,
		Tubes,
		Chocolate,
		Bananana
	}

	public class Recipe
	{
		public Resource Result { get; set; }
		public Resource[] Resources { get; set; }
	}

	public static Recipe[] Recipes =
	{
		new Recipe
		{
			Result = Resource.Engine,
			Resources = new Resource[]
			{
				Resource.Bunny,
				Resource.HamsterReel
			}
		},
		new Recipe
		{
			Result = Resource.Tubes,
			Resources = new Resource[]
			{
				Resource.Hammer,
				Resource.Chocolate
			}
		},
		new Recipe
		{
			Result = Resource.HamsterReel,
			Resources = new Resource[]
			{
				Resource.Cable,
				Resource.Cable
			}
		},
		new Recipe
		{
			Result = Resource.Cable,
			Resources = new Resource[]
			{
				Resource.Tubes,
				Resource.Tubes
			}
		},
		new Recipe
		{
			Result = Resource.Hammer,
			Resources = new Resource[]
			{
				Resource.Chocolate,
				Resource.Bananana
			}
		}
	};
}
