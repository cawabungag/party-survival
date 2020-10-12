using DB.Units.Characteristics;
using DB.Units.Characteristics.Impls;
using DB.Units.Prefabs;
using DB.Units.Prefabs.Impls;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class DatabaseInstaller : ScriptableObjectInstaller
	{
		[SerializeField] private UnitCharacteristicDatabase _unitCharacteristicDatabase;
		[SerializeField] private UnitPrefabDatabase _uniPrefabDatabase;

		public override void InstallBindings()
		{
			Container.Bind<IUnitCharacteristicDatabase>().FromInstance(_unitCharacteristicDatabase).AsSingle();
			Container.Bind<IUnitPrefabDatabase>().FromInstance(_uniPrefabDatabase).AsSingle();
		}
	}
}