using UnityEngine;
namespace Assets.CodeBase.Game
{
	public class Block : MonoBehaviour
	{
		[SerializeField] private RectTransform rectTransform = default;
		public RectTransform RectTransform => rectTransform;
	}
}
