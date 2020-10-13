using Ecs.Access;
using Entitas;
using Services.Items;

namespace Ecs.Item.Components
{
	[Item]
	public class ItemTypeComponent : IComponent
	{
		public EItemType Value;
	}

	public interface IItemTypeProperty : IProperty
	{
		EItemType ItemType { get; set; }
	}

	public class ItemTypePropertyAccess : IPropertyAccess<ItemEntity, IItemTypeProperty>
	{
		public void SetObjectValue(ItemEntity obj, IItemTypeProperty property)
		{
			obj.ReplaceEcsItemComponentsItemType(property.ItemType);
		}

		public void SetPropertyValue(ItemEntity obj, IItemTypeProperty property)
		{
			property.ItemType = obj.ecsItemComponentsItemType.Value;
		}

		public void Reset(IItemTypeProperty property)
		{
			property.ItemType = default;
		}
	}
}