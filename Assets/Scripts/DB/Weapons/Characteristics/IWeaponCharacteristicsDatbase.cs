using DB.Weapons.Characteristics.Impls;

namespace DB.Weapons.Characteristics
{
    public interface IWeaponCharacteristicsDatabase
    { 
        WeaponCharacteristicsVo GetWeaponCharacteristicsVo(EWeaponType weaponId); 
    }
}
