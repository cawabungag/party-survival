using DB.Weapons;
using DB.Weapons.Characteristics;
using DB.Weapons.Characteristics.Impls;
using DB.Weapons.Prefabs;
using Ecs.View;
using UnityEngine;
using Zenject;

namespace Services.Weapone.Impls.Strategies
{
	public class InstantiateWeaponStrategy : AInstantiateWeaponStrategy
	{
		private readonly DiContainer _diContainer;
		private readonly IWeaponCharacteristicsDatabase _weaponCharacteristicsDatabase;
		private readonly IWeaponPrefabDatabase _weaponPrefabDatabase;

		protected InstantiateWeaponStrategy(DiContainer diContainer,
			IWeaponCharacteristicsDatabase weaponCharacteristicsDatabase, IWeaponPrefabDatabase weaponPrefabDatabase) : base(diContainer, weaponPrefabDatabase)
		{
			_weaponCharacteristicsDatabase = weaponCharacteristicsDatabase;
		}

		public override bool CanInstantiate(GameEntity entity) => entity.isEcsItemComponentsWeapone; //Проверить

		public override ILinkable Create(GameEntity entity)
		{ 
			ILinkable linkable = base.Create(entity);
			EWeaponType weaponType = entity.ecsItemComponentsWeaponType.Value;
			WeaponCharacteristicsVo setting = _weaponCharacteristicsDatabase.GetWeaponCharacteristicsVo(weaponType);

			InitializeNonSerializableParameters(entity, setting);
			return linkable;
		}

		private void InitializeNonSerializableParameters(GameEntity entity, WeaponCharacteristicsVo setting)
		{
			entity.AddEcsGameWeaponsDamage(setting.Damage);
			entity.AddEcsGameWeaponsShells(setting.Shells);
			entity.AddEcsGameWeaponsFiringFrequency(setting.FiringFrequency);
		}
	}
}