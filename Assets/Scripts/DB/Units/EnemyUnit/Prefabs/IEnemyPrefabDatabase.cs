using DB.Units.EnemyUnit.Prefabs.Impls;

namespace DB.Units.EnemyUnit.Prefabs
{
   public interface IEnemyPrefabDatabase
   {
      EnemyPrafabVo GetZombiePrefab(EObjectType unitId);
   }
}
