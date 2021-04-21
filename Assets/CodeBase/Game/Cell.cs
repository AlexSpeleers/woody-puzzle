using UnityEngine;

namespace Assets.CodeBase.Game
{
	public class Cell : MonoBehaviour
	{
		[SerializeField] private RectTransform rectTransform = default;
		public RectTransform RectTransform => rectTransform;
		public bool IsReserved { get; private set; } = false;
		public void Reserv() 
		{
			IsReserved = true;
		}
		public void Refresh() 
		{
			IsReserved = false;
		}
	}
}
