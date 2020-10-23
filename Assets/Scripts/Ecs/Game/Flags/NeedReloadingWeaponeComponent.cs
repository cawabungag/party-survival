using Entitas;

namespace Ecs.Game.Flags
{
	[Game]
	public class NeedReloadingWeaponeComponent : IComponent
	{
		public bool Value;

		public override string ToString()
		{
			return $"Need reloading: {Value}";
		}
	}
}