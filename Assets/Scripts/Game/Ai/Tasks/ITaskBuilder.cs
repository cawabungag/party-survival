using CleverCrow.Fluid.BTs.Trees;

namespace Game.Ai.Tasks
{
	public interface ITaskBuilder
	{
		string Name { get; }

		void Fill(BehaviorTreeBuilder builder, GameEntity entity);

		void End(BehaviorTreeBuilder builder);
	}
}