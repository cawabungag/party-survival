namespace Ecs.Access
{
	public interface IAccess<TState>
	{
		void ReadState(TState state);
		void WriteState(TState state);
	}
}