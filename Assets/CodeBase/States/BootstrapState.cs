using Assets.CodeBase.AssetManagement;
using Assets.CodeBase.Factory;
using Assets.CodeBase.Services;

namespace Assets.CodeBase.States
{
	public class BootstrapState : IState
	{
		private readonly GameStateMachine gameStateMachine;
		private readonly AllServices services = default;
		public BootstrapState(GameStateMachine stateMachine, AllServices services)
		{
			gameStateMachine = stateMachine;
			this.services = services;
			RegisterServices();
		}
		public void Enter()
		{
			CreateUI();
			RunGameState();
		}

		public void Exit()
		{

		}
		private void RegisterServices()
		{
			services.RegisterSingle<IAssets>(new AssetProvider());
			services.RegisterSingle<IFactory>(new AssetFactory(services.Single<IAssets>()));
		}
		private void CreateUI() 
		{
			services.Single<IFactory>().CreateCanvas();
		}
		private void RunGameState() 
		{
			gameStateMachine.Enter<GameLoopState>();
		}
	}
}
