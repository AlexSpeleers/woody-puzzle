using Assets.CodeBase.States;
using UnityEngine;

namespace Assets.CodeBase.Boot
{
	public class GameBootStrapper : MonoBehaviour
	{
		private Game game = default;
		private void Awake()
		{
			game = new Game();
			game.StateMachine.Enter<BootstrapState>();
			DontDestroyOnLoad(this);
		}
	}
}