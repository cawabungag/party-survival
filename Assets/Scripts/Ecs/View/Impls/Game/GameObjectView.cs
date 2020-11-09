using DB.Weapons;
using UnityEngine;

namespace Ecs.View.Impls.Game
{
	public class GameObjectView : LinkableView<GameEntity>, IEcsGamePositionListener
	{
		protected override void Listen(GameEntity entity)
		{
			entity.AddEcsGamePositionListener(this);
			if (entity.hasEcsGamePosition)
				OnEcsGamePosition(entity, entity.ecsGamePosition.value);
		}

		protected override void Unlisten(GameEntity entity)
		{
			entity.RemoveEcsGamePositionListener(this);
		}

		protected override void InternalClear()
		{
			Destroy();
		}

		public void OnEcsGamePosition(GameEntity entity, Vector2 value) =>
			transform.position = new Vector3(value.x, 0, value.y);
		
	}
}