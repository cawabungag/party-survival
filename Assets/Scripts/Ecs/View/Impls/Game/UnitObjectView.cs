using DB.Units.MovementType;
using UnityEngine;

namespace Ecs.View.Impls.Game
{
	public class UnitObjectView : GameObjectView, IEcsGameMovementTypeListener
	{
		[SerializeField] private Animator _animator;

		public void OnEcsGameMovementType(GameEntity entity, EMovementType Value)
		{
			_animator.SetBool(AnimationKeys.GetAnimation(Value), true);
		}
	}
}