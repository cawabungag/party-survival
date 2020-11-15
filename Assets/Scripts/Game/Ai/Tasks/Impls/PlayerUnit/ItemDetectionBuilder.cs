using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using DB.Units;
using DB.Weapons;
using Entitas;
using UnityEngine;
using Zenject;

namespace Game.Ai.Tasks.Impls.PlayerUnit
{
	public class ItemDetectionBuilder : ABTreeBuilder
	{
		private static readonly ListPool<ItemEntity> ItemEntitiesListPool = ListPool<ItemEntity>.Instance;
		private readonly ItemContext _itemContext;

		public override string Name => TaskNames.FIND_ITEM;

		public ItemDetectionBuilder(
			ItemContext itemContext
		)
		{
			_itemContext = itemContext;
		}

		public override void Fill(BehaviorTreeBuilder builder, GameEntity entity)
			=> builder.Condition(Name, () =>
			{
				if (!entity.hasEcsGameUnitsPickingDistance || !entity.hasEcsGamePosition)
					return false;

				IGroup<ItemEntity> group = _itemContext.GetGroup(
					ItemMatcher.AllOf(ItemMatcher.EcsItemComponentsWeaponeType)
						.NoneOf(ItemMatcher.EcsCommonComponentsDestroyed));
				List<ItemEntity> buffer = ItemEntitiesListPool.Spawn();
				group.GetEntities(buffer);
				if (buffer.Count == 0)
					return false;

				Vector2 position = entity.ecsGamePosition.value;
				float pickingDistance = entity.ecsGameUnitsPickingDistance.Value;
				float rangeViewSqr = pickingDistance * pickingDistance;
				float closestItemSqrDistance = int.MaxValue;

				foreach (ItemEntity item in buffer)
				{
					if (!item.hasEcsItemComponentsPosition)
						continue;

					Vector2 itemPosition = item.ecsItemComponentsPosition.Value;
					Vector2 itemDistance = itemPosition - position;
					float itemDistanceSqrMagnitude = itemDistance.sqrMagnitude;
					if (itemDistanceSqrMagnitude > rangeViewSqr || closestItemSqrDistance < itemDistanceSqrMagnitude)
						continue;

					EWeaponType weaponType = item.ecsItemComponentsWeaponeType.Value;
					item.isEcsCommonComponentsDestroyed = true;

					if (!entity.hasEcsItemComponentsWeaponEquipped)
					{
						entity.AddEcsItemComponentsWeaponEquipped(weaponType);
					}
					else
					{
						entity.ReplaceEcsItemComponentsWeaponEquipped(weaponType);
					}
				}

				return false;
			});
	}
}