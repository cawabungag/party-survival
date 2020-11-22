using UnityEngine;

namespace Ecs.View.Impls.Game
{
	public class ItemObjectView : LinkableView<ItemEntity>, IEcsItemComponentsPositionListener
	{
		[SerializeField] private ParticleSystem _shootingEffect;
		[SerializeField] private AudioSource _shootingSound;
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
			//_shootingSound.Play();
			_shootingEffect.Play();
			transform.position = new Vector3(Value.x, 0, Value.y);
		}
		
	}
}