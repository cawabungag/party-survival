using DB.Units.EnemyUnit.Characteristics.Impls;

namespace DB.Units.EnemyUnit.Characteristics
{
   public interface IEnemyCharacteristicsDatabase
   { 
      EnemyCharacteristicVo GetCharacteristics(EObjectType unitId);
   }
}
