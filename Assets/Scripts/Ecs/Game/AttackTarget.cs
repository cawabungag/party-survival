using Ecs.Core;
using Entitas;

namespace Ecs.Game
{
	[Game]
	public class AttackTarget : IComponent
	{
		public Uid Value;

		public override string ToString() => "Target: " + Value;
	}
}