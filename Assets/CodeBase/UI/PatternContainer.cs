using Assets.CodeBase.Factory;
using UnityEngine;
using Grid = Assets.CodeBase.Game.Grid;

namespace Assets.CodeBase.UI
{
	public class PatternContainer : MonoBehaviour
	{
		[SerializeField] private RectTransform[] containers;
		private IFactory factory = default;
		private Canvas canvas = default;
		private Grid grid = default;
		internal void Construct(IFactory factory, Canvas canvas, Grid grid) 
		{
			this.factory = factory;
			this.canvas = canvas;
			this.grid = grid;
		}

		internal void PopulatePatterns()
		{
			foreach (var container in containers)
			{
				foreach (Transform child in container)
				{
					Destroy(child.gameObject);
				}
				factory.CreatePattern(container).Costruct(container, canvas, grid);
			}
		}
	}
}
