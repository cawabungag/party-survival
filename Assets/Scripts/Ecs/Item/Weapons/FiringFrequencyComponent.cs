using Entitas;

namespace Ecs.Item.Weapons
{
	[Item]
	public class FiringFrequencyComponent : IComponent
	{
		public float Value;

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}