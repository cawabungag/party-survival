using DB.Units.AiTasks;
using DB.Units.AiTasks.Impls;
using DB.Units.Characteristics;
using DB.Units.Characteristics.Impls;
using DB.Units.EnemyUnit.Characteristics;
using DB.Units.EnemyUnit.Characteristics.Impls;
using DB.Units.EnemyUnit.Prefabs;
using DB.Units.EnemyUnit.Prefabs.Impls;
using DB.Units.Prefabs;
using DB.Units.Prefabs.Impls;
using DB.Weapons.Characteristics;
using DB.Weapons.Characteristics.Impls;
using DB.Weapons.Prefabs;
using DB.Weapons.Prefabs.Impls;
using UnityEngine;
using Zenject;

namespace Installers
{
	[CreateAssetMenu(menuName = "Installers/DatabaseInstaller", fileName = "DatabaseInstaller")]
	public class DatabaseInstaller : ScriptableObjectInstaller
	{
		//Units
		[SerializeField] private UnitCharacteristicDatabase _unitCharacteristicDatabase;
		[SerializeField] private UnitPrefabDatabase _uniPrefabDatabase;

		//Enemy
		[SerializeField] private EnemyCharacteristicsDatabase _enemyCharacteristicsDatabase;
		[SerializeField] private EnemyPrefabDatabase _enemyPrefabDatabase;

		//Ai
		[SerializeField] private AiTaskDatabase _aiTaskDatabase;

		//Weapones
		[SerializeField] private WeaponCharacteristicsDatabase _weaponeCharacteristicDatabase;
		[SerializeField] private WeaponPrefabDatabase _weaponePrefabDatabase;


		public override void InstallBindings()
		{
			//Units
			Container.Bind<IUnitCharacteristicDatabase>().FromInstance(_unitCharacteristicDatabase).AsSingle();
			Container.Bind<IUnitPrefabDatabase>().FromInstance(_uniPrefabDatabase).AsSingle();

			//Enemy
			Container.Bind<IEnemyCharacteristicsDatabase>().FromInstance(_enemyCharacteristicsDatabase).AsSingle();
			Container.Bind<IEnemyPrefabDatabase>().FromInstance(_enemyPrefabDatabase).AsSingle();

			//Ai
			Container.Bind<IAiTaskDatabase>().FromInstance(_aiTaskDatabase).AsSingle();

			//Weapones
			Container.Bind<IWeaponPrefabDatabase>().FromInstance(_weaponePrefabDatabase).AsSingle();
			Container.Bind<IWeaponCharacteristicsDatabase>().FromInstance(_weaponeCharacteristicDatabase).AsSingle();
		}
	}
}