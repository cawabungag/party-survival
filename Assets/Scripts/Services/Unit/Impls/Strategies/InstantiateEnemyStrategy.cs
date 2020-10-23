using DB.Units;
using DB.Units.EnemyUnit.Characteristics;
using DB.Units.EnemyUnit.Characteristics.Impls;
using DB.Units.EnemyUnit.Prefabs;
using Ecs.View;
using Zenject;

namespace Services.Unit.Impls.Strategies
{
	public class InstantiateEnemyStrategy : AInstantiateEnemyStrategy
	{
		private readonly DiContainer _diContainer;
		private readonly IEnemyCharacteristicsDatabase _enemyCharacteristicDatabase;
		private readonly IEnemyPrefabDatabase _enemyPrefabDatabase;

		public InstantiateEnemyStrategy(
			DiContainer diContainer,
			IEnemyCharacteristicsDatabase enemyCharacteristicDatabase,
			IEnemyPrefabDatabase enemyPrefabDatabase
		) : base(diContainer, enemyPrefabDatabase)
		{
			_enemyCharacteristicDatabase = enemyCharacteristicDatabase;
		}

		public override bool CanInstantiate(GameEntity entity) => entity.isEcsGameFlagsUnit;

		public override ILinkable Create(GameEntity entity)
		{
			ILinkable linkable = base.Create(entity);
			EObjectType unitType = entity.ecsGameObjectType.Value;
			EnemyCharacteristicVo setting = _enemyCharacteristicDatabase.GetCharacteristics(unitType);
			InitializeNonSerializableParameters(entity, setting);
			return linkable;
		}

		private void InitializeNonSerializableParameters(GameEntity entity, EnemyCharacteristicVo setting)
		{
			entity.AddEcsGameUnitsMaxHealth(setting.Health);
			entity.AddEcsGameUnitsHealth(setting.Health);
			entity.AddEcsGameUnitsSpeed(setting.Speed);
			entity.AddEcsGameUnitsRangeView(setting.RangeView);
		}
	}
}