using DB.Units;
using DB.Weapons.Prefabs.Impls;

namespace DB.Weapons.Prefabs
{
    public interface IWeaponPrefabDatabase
    {
        WeaponPrefabVo GetWeaponPrefabVoPrefab(EWeaponType weaponId);
    }
}
