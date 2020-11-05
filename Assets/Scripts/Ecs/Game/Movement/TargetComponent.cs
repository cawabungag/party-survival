using Ecs.Core;
using Entitas;

namespace Ecs.Game
{
	[Game]
	public class TargetComponent : IComponent
	{
		public Uid Value;

		public override string ToString()
		{
			return $"Target: {Value}";
		}
	}
}