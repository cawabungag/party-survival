using DB.Units.MovementType;
using UnityEngine;

namespace Ecs.View.Impls.Game
{
	public class EnemyObjectView : GameObjectView, IEcsGameMovementTypeListener, IEcsGameVelocityListener
	{
		[SerializeField] private Animator _animator;

		protected override void Listen(GameEntity entity)
		{
			entity.AddEcsGameMovementTypeListener(this);
			entity.AddEcsGameVelocityListener(this);
			base.Listen(entity);
		}

		public void OnEcsGameMovementType(GameEntity entity, EMovementType Value)
		{
			_animator.SetBool(AnimationKeys.GetAnimation(Value), true);
		}

		public void OnEcsGameVelocity(GameEntity entity, Vector2 Value)
		{
			Vector3 newPos = new Vector3(Value.x, 0, Value.y);
			Vector3 currentPos = transform.position;
			Vector3 facePos = currentPos + newPos;
			transform.LookAt(facePos);
		}
	}
}