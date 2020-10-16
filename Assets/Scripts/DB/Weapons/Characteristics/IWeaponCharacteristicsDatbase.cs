using DB.Units;
using DB.Weapons.Characteristics.Impls;

namespace DB.Weapons.Characteristics
{
    public interface IWeaponCharacteristicsDatabase
    { 
        WeaponCharacteristicsVo GetWeaponCharacteristicsVO(EObjectType weaponId);
    }
}
