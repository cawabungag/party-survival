using DB.Units.EnemyUnit.Prefabs;
using DB.Units.Prefabs;
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

            IEnemyPrefabDatabase enemyDatabase
        )
        {
            _enemyDatabase = enemyDatabase;
        }

        public abstract bool CanInstantiate(GameEntity entity);

        public virtual ILinkable Create(GameEntity entity)
        {
            var enemyType = entity.ecsGameObjectType.Value;
            var enemy = _enemyDatabase.GetZombiePrefab(enemyType);
            var unit = _enemyDatabase.GetZombiePrefab(enemyType);
            var view = _diContainer.InstantiatePrefabForComponent<GameObjectView>(unit.Prefab, entity.ecsGamePosition.value,

            Quaternion.identity, null);
			
            return view;
        }
    }

   
}
