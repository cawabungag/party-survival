using DB.Units.MovementType;
using UnityEngine;

namespace Ecs.View.Impls.Game
{
	public class UnitObjectView : GameObjectView, IEcsGameMovementTypeListener, IEcsGameVelocityListener
	{
		[SerializeField] private Animator _animator;

		protected override void Listen(GameEntity entity)
		{
			entity.AddEcsGameMovementTypeListener(this);
			entity.AddEcsGameVelocityListener(this);
			base.Listen(entity);
		}

		public void OnEcsGameMovementType(GameEntity entity, EMovementType value)
		{
			_animator.SetBool(AnimationKeys.GetAnimation(value), true);
		}

		public void OnEcsGameVelocity(GameEntity entity, Vector2 value)
		{
			Vector3 newPos = new Vector3(value.x, 0, value.y);
			Vector3 currentPos = transform.position;
			Vector3 facePos = currentPos + newPos;
			transform.LookAt(facePos);
		}
	}
}