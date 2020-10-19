using DB.Units;
using DB.Units.Characteristics;
using DB.Units.Characteristics.Impls;
using DB.Units.EnemyUnit.Characteristics;
using DB.Units.EnemyUnit.Characteristics.Impls;
using DB.Units.EnemyUnit.Prefabs;
using DB.Units.Prefabs;
using Ecs.View;
using Services.Unit.Impls.Strategies;
using Zenject;


public class InstantiateEnemyStrategy : AInstantiateEnemyStrategy 
{
        private readonly IEnemyCharacteristicsDatabase _enemyCharacteristicDatabase;
        private readonly IEnemyPrefabDatabase _enemyPrefabDatabase;


        public InstantiateEnemyStrategy(
            
            IEnemyCharacteristicsDatabase enemyCharacteristicDatabase,
            IEnemyPrefabDatabase enemyPrefabDatabase
        ) : base(enemyPrefabDatabase)
        {
            _enemyCharacteristicDatabase = enemyCharacteristicDatabase;
        }

        public override bool CanInstantiate(GameEntity entity) => entity.isEcsGameFlagsUnit;

        public override ILinkable Create(GameEntity entity)
        {
            var linkable = base.Create(entity);
            var unitType = entity.ecsGameObjectType.Value;
            var setting = _enemyCharacteristicDatabase.GetCharacteristics(unitType);
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