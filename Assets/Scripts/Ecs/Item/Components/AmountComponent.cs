using Ecs.Access;
using Entitas;

namespace Ecs.Item.Components
{
	[Item]
	public class AmountComponent : IComponent
	{
		public int Value;
	}

	public interface IAmountProperty : IProperty
	{
		int Amount { get; set; }
	}

	public class AmountPropertyAccess : IPropertyAccess<ItemEntity, IAmountProperty>
	{
		public void SetObjectValue(ItemEntity obj, IAmountProperty property)
		{
			obj.RemoveEcsItemComponentsAmount();
		}

		public void SetPropertyValue(ItemEntity obj, IAmountProperty property)
		{
			property.Amount = obj.ecsItemComponentsAmount.Value;
		}

		public void Reset(IAmountProperty property)
		{
			property.Amount = default;
		}
	}
}