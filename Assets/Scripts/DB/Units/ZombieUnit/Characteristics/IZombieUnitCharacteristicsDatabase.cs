using DB.Units.ZombieUnit.Characteristics.Impls;

namespace DB.Units.ZombieUnit.Characteristics
{
   public interface IZombieCharacteristicsDatabase
   {
      ZombieUnitCharacteristicVo GetCharacteristics(EObjectType unitId);
   }
}
