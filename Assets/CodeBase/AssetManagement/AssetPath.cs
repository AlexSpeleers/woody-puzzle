using System.Collections.Generic;

namespace Assets.CodeBase.AssetManagement
{
	public static class AssetPath
	{
		public const string UIContainer = "Prefabs/UI/UI";
		public const string Cell = "Prefabs/UI/BoardCell";
		public static List<string> Patterns = new List<string> 
		{
			"Prefabs/GameObjects/Dot",
			"Prefabs/GameObjects/FiveDots",
			"Prefabs/GameObjects/FourDots",
			"Prefabs/GameObjects/Horse",
			"Prefabs/GameObjects/HorseFliped",
			"Prefabs/GameObjects/LargeTriangle",
			"Prefabs/GameObjects/SmallTriangle",
			"Prefabs/GameObjects/TwoDots",
		};
	}
}
