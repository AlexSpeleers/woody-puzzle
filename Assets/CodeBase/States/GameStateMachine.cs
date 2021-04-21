using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;

namespace Assets.CodeBase.States
{
	public class GameStateMachine
	{
		private readonly Dictionary<Type, IState> states;
		private IState activeState;
		public GameStateMachine(AllServices services)
		{
			states = new Dictionary<Type, IState>()
			{
				[typeof(BootstrapState)] = new BootstrapState(this, services),
				[typeof(GameLoopState)] = new GameLoopState(this)
			};
		}
		public void Enter<TState>() where TState : class, IState
		{
			IState state = ChangeState<TState>();
			state.Enter();
		}

		private TState ChangeState<TState>() where TState : class, IState
		{
			activeState?.Exit();
			TState state = GetState<TState>();
			activeState = state;
			return state;
		}

		private TState GetState<TState>() where TState : class, IState =>
		states[typeof(TState)] as TState;
	}
}
