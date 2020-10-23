using DB.Units;
using DB.Units.EnemyUnit.Prefabs;
using DB.Units.EnemyUnit.Prefabs.Impls;
using Ecs.View;
using Ecs.View.Impls.Game;
using UnityEngine;
using Zenject;

namespace Services.Unit.Impls.Strategies
{
	public abstract class AInstantiateEnemyStrategy : IInstantiateUnitStrategy
	{
		private readonly DiContainer _diContainer;
		private readonly IEnemyPrefabDatabase _enemyDatabase;

		protected AInstantiateEnemyStrategy(
			DiContainer diContainer,
			IEnemyPrefabDatabase enemyDatabase
		)
		{
			_diContainer = diContainer;
			_enemyDatabase = enemyDatabase;
		}

		public abstract bool CanInstantiate(GameEntity entity);

		public virtual ILinkable Create(GameEntity entity)
		{
			EObjectType enemyType = entity.ecsGameObjectType.Value;
			EnemyPrafabVo enemy = _enemyDatabase.GetZombiePrefab(enemyType);
			GameObjectView view = _diContainer.InstantiatePrefabForComponent<GameObjectView>(enemy.Prefab,
				entity.ecsGamePosition.value,
				Quaternion.identity, null);

			return view;
		}
	}
}