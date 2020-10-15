using DB.Units.Characteristics;
using DB.Units.Prefabs;
using Ecs.View;
using Ecs.View.Impls.Game;
using UnityEngine;
using Zenject;

namespace Services.Unit.Impls.Strategies
{
	public abstract class AInstantiateUnitStrategy : IInstantiateUnitStrategy
	{
		private readonly DiContainer _diContainer;
		private readonly IUnitPrefabDatabase _unitDatabase;

		protected AInstantiateUnitStrategy(
			DiContainer diContainer,
			IUnitPrefabDatabase unitDatabase
		)
		{
			_diContainer = diContainer;
			_unitDatabase = unitDatabase;
		}

		public abstract bool CanInstantiate(GameEntity entity);

		public virtual ILinkable Create(GameEntity entity)
		{
			var unitType = entity.ecsGameObjectType.Value;
			var unit = _unitDatabase.GetUnitPrefab(unitType);
			var view = _diContainer.InstantiatePrefabForComponent<GameObjectView>(unit.Prefab, entity.ecsGamePosition.value,
				Quaternion.identity, null);
			
			return view;
		}
	}
}