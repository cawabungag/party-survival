using Entitas;

namespace Ecs.Item.Weapons
{
	[Item]
	public class ShellsComponent : IComponent
	{
		public float Value;

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}