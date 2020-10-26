using CleverCrow.Fluid.BTs.Trees;
using Entitas;

namespace Ecs.Ai
{
	[Game]
	public class BehaviourTreeComponent : IComponent
	{
		public IBehaviorTree Value;

		public override string ToString() => "HasBehaviourTree";
	}
}