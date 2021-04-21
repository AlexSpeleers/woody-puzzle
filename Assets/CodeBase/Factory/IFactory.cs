using Assets.CodeBase.Game;
using Assets.CodeBase.Services;
using UnityEngine;

namespace Assets.CodeBase.Factory
{
	public interface IFactory : IService
	{
		void CreateCanvas();
		Pattern CreatePattern(Transform transform);
		Cell CreateCell(Transform transform);
	}
}
