using DB.Units.Characteristics;
using DB.Units.Characteristics.Impls;
using DB.Units.Prefabs;
using Ecs.View;
using Zenject;

namespace Services.Unit.Impls.Strategies
{
	public class InstantiateUnitStrategy : AInstantiateUnitStrategy
	{
		private readonly DiContainer _diContainer;
		private readonly IUnitCharacteristicDatabase _unitCharacteristicDatabase;
		private readonly IUnitPrefabDatabase _unitPrefabDatabase;


		public InstantiateUnitStrategy(
			DiContainer diContainer,
			IUnitCharacteristicDatabase unitCharacteristicDatabase,
			IUnitPrefabDatabase unitPrefabDatabase
		) : base(diContainer, unitPrefabDatabase)
		{
			_unitCharacteristicDatabase = unitCharacteristicDatabase;
		}

		public override bool CanInstantiate(GameEntity entity) => entity.isEcsGameFlagsUnit;

		public override ILinkable Create(GameEntity entity)
		{
			var linkable = base.Create(entity);
			var unitType = entity.ecsGameObjectType.Value;
			var setting = _unitCharacteristicDatabase.GetCharacteristics(unitType);
			InitializeNonSerializableParameters(entity, setting);
			return linkable;
		}

		private void InitializeNonSerializableParameters(GameEntity entity, UnitCharacteristicVo setting)
		{
			entity.AddEcsGameUnitsMaxHealth(setting.Health);
			entity.AddEcsGameUnitsHealth(setting.Health);
			entity.AddEcsGameUnitsSpeed(setting.Speed);
			entity.AddEcsGameUnitsRangeView(setting.RangeView);
		}
	}
}