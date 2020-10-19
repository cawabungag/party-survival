using DB.Units.ZombieUnit.Prefabs.Impls;

namespace DB.Units.ZombieUnit.Prefabs
{
   public interface IZombieUnitPrefabDatabase
   {
      ZombieUnitPrafabVo GetZombiePrefab(EObjectType unitId);
   }
}
