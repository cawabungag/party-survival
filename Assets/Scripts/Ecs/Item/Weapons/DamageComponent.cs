using Entitas;

namespace Ecs.Item.Weapons
{
	[Item, Game]
	public class DamageComponent : IComponent
	{
		public float Value;

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}