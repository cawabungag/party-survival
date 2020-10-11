using Zenject;

namespace Ecs.Access.Pool
{
	public class StatePool<TState, TAccess> : MemoryPool<TState>
		where TState : TAccess
		where TAccess : IProperty
	{
		private readonly IStateReset<TAccess> _stateReset;

		public StatePool(IStateReset<TAccess> stateReset)
		{
			_stateReset = stateReset;
		}

		protected override void OnDespawned(TState item)
		{
			_stateReset.Reset(item);
		}
	}
}