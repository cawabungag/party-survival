using Ecs.Common.Components;
using Ecs.Item.Components;

namespace Ecs.Access.States.Impls.Access
{
	public class ItemStatePropertyAccess : StatePropertyAccess<ItemEntity, IItemState>
	{
		public override void Initialize()
		{
			AddOriginator<UidPropertyAccess>();
			AddOriginator<OwnerPropertyAccess>();
			AddOriginator<ItemTypePropertyAccess>();
			AddOriginator<AmountPropertyAccess>();
		}
	}
}