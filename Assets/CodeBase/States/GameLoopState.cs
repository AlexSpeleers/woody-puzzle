namespace Assets.CodeBase.States
{
	public class GameLoopState : IState
	{
		private GameStateMachine gameStateMachine = default;
		public GameLoopState(GameStateMachine gameStateMachine)
		{
			this.gameStateMachine = gameStateMachine;
		}
		public void Enter()
		{

		}

		public void Exit()
		{

		}
	}
}
