using Assets.CodeBase.Services;
using UnityEngine;

namespace Assets.CodeBase.AssetManagement
{
	public interface IAssets : IService
	{
		GameObject Instantiate(string path, Transform parent = null);
	}
}
