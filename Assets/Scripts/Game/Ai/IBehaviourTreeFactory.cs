using CleverCrow.Fluid.BTs.Trees;
using Zenject;

namespace Game.Ai
{
	public interface IBehaviourTreeFactory : IFactory<GameEntity, IBehaviorTree>
	{
	}
}