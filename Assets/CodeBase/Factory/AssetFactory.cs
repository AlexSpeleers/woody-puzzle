using Assets.CodeBase.AssetManagement;
using Assets.CodeBase.Game;
using Assets.CodeBase.UI;
using UnityEngine;

namespace Assets.CodeBase.Factory
{
	public class AssetFactory : IFactory
	{
		private readonly IAssets assets;
		public AssetFactory(IAssets assets)
		{
			this.assets = assets;
		}
		public void CreateCanvas()
		{
			assets.Instantiate(AssetPath.UIContainer).GetComponent<UIController>().Construct(this);
		}

		public Pattern CreatePattern(Transform transform) => 
			assets.Instantiate(AssetPath.Patterns[Random.Range(0, AssetPath.Patterns.Count)], transform).GetComponent<Pattern>();
		public Cell CreateCell(Transform transform) => 
			assets.Instantiate(AssetPath.Cell, transform).GetComponent<Cell>();
	}
}
