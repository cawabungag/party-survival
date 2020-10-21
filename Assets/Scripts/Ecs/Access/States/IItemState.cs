using Ecs.Common.Components;
using Ecs.Item.Components;

namespace Ecs.Access.States
{
	public interface IItemState :
		IUidProperty,
		IOwnerProperty,
		IItemTypeProperty,
		IAmountProperty
	{
	}
}