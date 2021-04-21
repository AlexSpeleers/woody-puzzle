using UnityEngine;

namespace Assets.CodeBase.Boot
{
	public class EntryPoint : MonoBehaviour
	{
		public GameBootStrapper GameBootStrapper = default;
		private void Awake()
		{
			var bootStrapper = FindObjectOfType<GameBootStrapper>();
			if (bootStrapper == null)
			{
				Instantiate(GameBootStrapper);
			}
		}
	}
}
