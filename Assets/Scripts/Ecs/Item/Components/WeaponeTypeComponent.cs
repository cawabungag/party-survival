using DB.Weapons;
using Entitas;

namespace Ecs.Item.Components
{
	[Item]
	public class WeaponeTypeComponent : IComponent
	{
		public EWeaponType Value;

		public override string ToString()
		{
			return $"Weapone type: {Value}";
		}
	}
}