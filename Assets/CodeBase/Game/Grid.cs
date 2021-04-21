using Assets.CodeBase.Factory;
using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Game
{
	public class Grid : MonoBehaviour
	{
		[SerializeField] private RectTransform fieldRect = default;
		[SerializeField] private int columns = default, rows = default;

		private Canvas canvas = default;
		private IFactory factory = default;
		private Cell[,] gridCells;
		[SerializeField] private int marginVert = default, marginHor = default, spacingBetween = default;

		[Header("NonAloc")]
		private float width, height, cellWidth, cellHeight;
#region Getters
		public RectTransform FieldRect => fieldRect;
		public Cell[,] GridCells => gridCells;
#endregion
		internal void Construct(IFactory factory, Canvas canvas)
		{
			this.canvas = canvas;
			this.factory = factory;
		}
		internal void ShowBoard()
		{
			if (gridCells != null)
			{
				foreach (Cell cell in gridCells)
				{
					cell.Refresh();
				}
			}
			else
			{
				StartCoroutine(CreateBoard());
			}
		}
		private IEnumerator CreateBoard() 
		{
			//wait one frame for canvas recalculations
			yield return null;
			width = fieldRect.rect.size.x;
			height = fieldRect.rect.size.y;
			cellWidth = (width - marginHor * 2 - spacingBetween * (columns - 1)) / columns;
			cellHeight = (height - marginVert * 2 - spacingBetween * (rows - 1)) / rows;
			gridCells = new Cell[columns, rows];
			for (int i = 0; i < columns; i++)
			{
				for (int k = 0; k < rows; k++)
				{
					gridCells[i, k] = factory.CreateCell(fieldRect);
					gridCells[i, k].RectTransform.anchorMin = Vector2.zero;
					gridCells[i, k].RectTransform.anchorMax = Vector2.zero;
					gridCells[i, k].RectTransform.pivot = Vector2.zero;
					gridCells[i, k].RectTransform.sizeDelta = Vector2.right * cellWidth + Vector2.up * cellHeight;
					gridCells[i, k].RectTransform.anchoredPosition = Vector2.right * (marginHor + spacingBetween * i + cellWidth * i)
						+ Vector2.up * (marginVert + spacingBetween * k + cellHeight * k);
				}
			}
		}
	}
}