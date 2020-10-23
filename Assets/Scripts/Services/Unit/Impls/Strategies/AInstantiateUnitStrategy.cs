using DB.Units;
using DB.Units.Prefabs;
using DB.Units.Prefabs.Impls;
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
			EObjectType unitType = entity.ecsGameObjectType.Value;
			UnitPrefabVo unit = _unitDatabase.GetUnitPrefab(unitType);
			UnitObjectView view = _diContainer.InstantiatePrefabForComponent<UnitObjectView>(unit.Prefab, entity.ecsGamePosition.value,
				Quaternion.identity, null);
			
			return view;
		}
	}
}