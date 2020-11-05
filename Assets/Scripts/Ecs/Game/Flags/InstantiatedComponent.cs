using Entitas;

namespace Ecs.Game.Flags
{
	[Game, Item]
	public class InstantiatedComponent : IComponent
	{
		public override string ToString()
		{
			return "Is Instantiated";
		}
	}
}