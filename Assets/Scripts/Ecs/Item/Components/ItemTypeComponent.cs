using Entitas;
using Services.Items;

namespace Ecs.Item.Components
{
	[Item]
	public class ItemTypeComponent : IComponent
	{
		public EItemType Value;

		public override string ToString()
		{
			return $"Item type: {Value}";
		}
	}
}