using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Ecs.Core;
using UnityEngine;

namespace Game.Ai.Tasks.Impls.PlayerUnit
{
	public class PickingUpItemBuilder : ABTreeBuilder
	{
		private readonly ItemContext _item;

		public PickingUpItemBuilder(ItemContext item)
		{
			_item = item;
		}

		public override string Name => TaskNames.PICK_UP_ITEM;

		public override void Fill(BehaviorTreeBuilder builder, GameEntity entity)
			=> builder.Do(Name, () =>
			{
				if (!entity.hasEcsGamePosition)
					return TaskStatus.Failure; Debug.Log("Fail");
				

				Uid itemUid = entity.ecsItemComponentsPickingItem.Value;
				ItemEntity itemEntity = _item.GetEntityWithEcsCommonComponentsUid(itemUid);
				
				itemEntity.Destroy();
				Debug.Log("ItemDestroy/Equipped");



				    return TaskStatus.Success;
			});
	}
}