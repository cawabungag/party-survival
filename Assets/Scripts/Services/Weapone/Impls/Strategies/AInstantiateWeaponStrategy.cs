using DB.Weapons;
using DB.Weapons.Prefabs;
using DB.Weapons.Prefabs.Impls;
using Ecs.View;
using Ecs.View.Impls.Game;
using UnityEngine;
using Zenject;

namespace Services.Weapone.Impls.Strategies
{
    public abstract class AInstantiateWeaponStrategy : IInstantiateWeaponStrategy
    {
        private readonly DiContainer _diContainer;
        private readonly IWeaponPrefabDatabase _weaponDatabase;

        protected AInstantiateWeaponStrategy(
            DiContainer diContainer,
            IWeaponPrefabDatabase unitDatabase
        )
        {
            _diContainer = diContainer;
            _weaponDatabase = unitDatabase;
        }
        
        public abstract bool CanInstantiate(GameEntity entity);
        
        public virtual ILinkable Create(GameEntity entity)
        {
            Debug.Log("WeaponInstantiated");
            EWeaponType weaponType = entity.ecsItemComponentsWeaponType.Value;
            WeaponPrefabVo weapon = _weaponDatabase.GetWeaponPrefab(weaponType);
            GameObjectView view = _diContainer.InstantiatePrefabForComponent<GameObjectView>(weapon.Prefab, entity.ecsGamePosition.value,
                Quaternion.identity, null);
            return view;
        }
    }
}