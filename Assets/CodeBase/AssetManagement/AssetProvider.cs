using UnityEngine;

namespace Assets.CodeBase.AssetManagement
{
	public class AssetProvider : IAssets
	{
		public GameObject Instantiate(string path, Transform parent = null)
		{
			var prefab = Resources.Load<GameObject>(path);
			if (parent != null) 
			{
				return Object.Instantiate(prefab, parent);
			}
			return Object.Instantiate(prefab);
		}
	}
}
