using DB.Units.MovementType;
using DB.Weapons;
using UnityEngine;

namespace Ecs.View.Impls.Game
{
	public class UnitObjectView : GameObjectView, IEcsGameMovementTypeListener, IEcsGameVelocityListener, IEcsItemComponentsWeaponEquippedListener, IEcsGameUnitsHealthListener
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private HealthBar _healthBar;
		[SerializeField] private AudioSource _footSteep;
		protected override void Listen(GameEntity entity)
		{
			entity.AddEcsGameMovementTypeListener(this);
			entity.AddEcsGameVelocityListener(this);
			entity.AddEcsItemComponentsWeaponEquippedListener(this);
			entity.AddEcsGameUnitsHealthListener(this);
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
		
		public void OnEcsItemComponentsWeaponEquipped(GameEntity entity, EWeaponType Value)
		{
			Debug.Log("Weapon Equipped");
		}
		
		public void OnEcsGameUnitsHealth(GameEntity entity, float Value)
		{
			_healthBar.SetHealth(entity.ecsGameUnitsHealth.Value);
		}
	}
}