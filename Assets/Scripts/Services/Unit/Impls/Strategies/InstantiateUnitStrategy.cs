using DB.Units;
using DB.Units.Characteristics;
using DB.Units.Characteristics.Impls;
using DB.Units.Prefabs;
using Ecs.View;
using Game.Ai;
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
			IUnitPrefabDatabase unitPrefabDatabase, IBehaviourTreeFactory behaviourTreeFactory
		) : base(diContainer, unitPrefabDatabase, behaviourTreeFactory)
		{
			_unitCharacteristicDatabase = unitCharacteristicDatabase;
		}

		public override bool CanInstantiate(GameEntity entity) => entity.isEcsGameFlagsUnit || entity.isEnemy;

		public override ILinkable Create(GameEntity entity)
		{
			ILinkable linkable = base.Create(entity);
			EObjectType unitType = entity.ecsGameObjectType.Value;
			UnitCharacteristicVo setting = _unitCharacteristicDatabase.GetCharacteristics(unitType);
			InitializeNonSerializableParameters(entity, setting);
			return linkable;
		}

		private void InitializeNonSerializableParameters(GameEntity entity, UnitCharacteristicVo setting)
		{
			entity.AddEcsGameUnitsMaxHealth(setting.Health);
			entity.AddEcsGameUnitsHealth(setting.Health);
			entity.AddEcsGameUnitsSpeed(setting.Speed);
			entity.AddEcsGameUnitsRangeView(setting.RangeView);
			entity.AddEcsGameUnitsPickingDistance(setting.PickingDistance);
		}
	}
}