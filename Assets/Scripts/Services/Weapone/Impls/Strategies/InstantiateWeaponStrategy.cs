using DB.Weapons;
using DB.Weapons.Characteristics;
using DB.Weapons.Characteristics.Impls;
using DB.Weapons.Prefabs;
using Ecs.View;
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

		public override bool CanInstantiate(ItemEntity entity) => entity.hasEcsItemComponentsWeaponeType;

		public override ILinkable Create(ItemEntity entity)
		{
			ILinkable linkable = base.Create(entity);
			EWeaponType weaponType = entity.ecsItemComponentsWeaponeType.Value;
			WeaponCharacteristicsVo setting = _weaponCharacteristicsDatabase.GetWeaponCharacteristicsVo(weaponType);
			InitializeNonSerializableParameters(entity, setting);
			return linkable;
		}

		private void InitializeNonSerializableParameters(ItemEntity entity, WeaponCharacteristicsVo setting)
		{
			entity.AddEcsItemWeaponsDamage(setting.Damage);
			entity.AddEcsItemWeaponsShells(setting.Shells);
			entity.AddEcsItemWeaponsFiringFrequency(setting.FiringFrequency);
		}
	}
}