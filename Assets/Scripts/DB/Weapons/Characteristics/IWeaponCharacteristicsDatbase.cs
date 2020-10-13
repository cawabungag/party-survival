using DB.Weapons.Characteristics.Impls;

namespace DB.Weapons.Characteristics
{
    public interface IWeaponCharacteristicsDatbase
    { 
        WeaponCharacteristicsVo GetWeaponCharacteristicsVO(string weaponId);
    }
}
