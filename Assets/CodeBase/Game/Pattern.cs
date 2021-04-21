using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Grid = Assets.CodeBase.Game.Grid;

namespace Assets.CodeBase.Game
{
	public class Pattern : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
	{
		[SerializeField] Block[] blocks = default;
		[SerializeField] private PatternType patternType = default;
		[SerializeField] private RectTransform selfRect = default;

		private Canvas canvas = default;
		private RectTransform parent = default;
		private Grid grid = default;
		private float minSnapDST = 20.0f;
		public PatternType PatternType => patternType;

		private List<Cell> results = null;

		internal void Costruct(RectTransform parent, Canvas canvas, Grid grid) 
		{
			this.canvas = canvas;
			this.parent = parent;
			this.grid = grid;
			results = new List<Cell>();
		}

		public void OnDrag(PointerEventData eventData)
		{
			Debug.Log("drag");
			selfRect.anchoredPosition += eventData.delta / canvas.scaleFactor;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			Debug.Log("down");
			selfRect.parent = grid.FieldRect;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			Debug.Log("up");
			results.Clear();
			results.TrimExcess();
			foreach (Block block in blocks)
			{
				CheckCorrespondence(block.RectTransform);
			}
			if (results.Count == blocks.Length)
			{
				for (int i = 0; i < results.Count; i++)
				{
					blocks[i].RectTransform.parent = results[i].RectTransform;
					blocks[i].RectTransform.anchoredPosition = results[i].RectTransform.anchoredPosition;
				}
				Destroy(this.gameObject);
			}
			else 
			{
				selfRect.parent = parent;
				selfRect.anchoredPosition = parent.anchoredPosition;
			}
		}
		private void CheckCorrespondence(RectTransform target) 
		{
			foreach (Cell cell in grid.GridCells)
			{
				if ((cell.RectTransform.anchoredPosition - target.anchoredPosition).sqrMagnitude <= minSnapDST && !cell.IsReserved) 
				{
					results.Add(cell);
					break;
				}
			}
		}
	}
	public enum PatternType 
	{
		Dot,
		TwoDots,
		FourDots,
		FiveDots,
		SmallTriangle,
		LargeTriangle,
		Horse,
		HorseFliped
	}
}
