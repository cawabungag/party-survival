using DB.Weapons;
using UnityEngine;

namespace Ecs.View.Impls.Game
{
	public class ItemObjectView : LinkableView<ItemEntity>, IEcsItemComponentsPositionListener
	{
		protected override void Listen(ItemEntity entity)
		{
			entity.AddEcsItemComponentsPositionListener(this);
			if (entity.hasEcsItemComponentsPosition)
				OnEcsItemComponentsPosition(entity, entity.ecsItemComponentsPosition.Value);
		}

		protected override void Unlisten(ItemEntity entity)
		{
			entity.RemoveEcsItemComponentsPositionListener(this);
		}

		protected override void InternalClear()
		{
			Destroy();
		}

		public void OnEcsItemComponentsPosition(ItemEntity entity, Vector3 Value)
		{
			transform.position = new Vector3(Value.x, 0, Value.y);
		}
		
	}
}