using Assets.CodeBase.Services;
using Assets.CodeBase.States;

namespace Assets.CodeBase.Boot
{
	public class Game
	{
		public GameStateMachine StateMachine { get; private set; }
		public Game()
		{
			StateMachine = new GameStateMachine(AllServices.Container);
		}
	}
}
