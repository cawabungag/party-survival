namespace Ecs.Access
{
	public interface IObjectAccess<TObject, TState> : IStateReset<TState>
	{
		void SetState(TObject obj, TState state);
		void GetState(TObject obj, ref TState state);
	}

	public interface IStateReset<TState>
	{
		void Reset(TState state);
	}
}