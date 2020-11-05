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

		public abstract bool CanInstantiate(ItemEntity entity);

		public virtual ILinkable Create(ItemEntity entity)
		{
			EWeaponType weaponType = entity.ecsItemComponentsWeaponeType.Value;
			WeaponPrefabVo weapon = _weaponDatabase.GetWeaponPrefab(weaponType);
			ItemObjectView view = _diContainer.InstantiatePrefabForComponent<ItemObjectView>(weapon.Prefab, entity.ecsItemComponentsPosition.Value,
				Quaternion.identity, null);
			return view;
		}
	}
}