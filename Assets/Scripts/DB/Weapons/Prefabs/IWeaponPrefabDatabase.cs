using DB.Weapons.Prefabs.Impls;

namespace DB.Weapons.Prefabs
{
    public interface IWeaponPrefavDatabase
    {
        WeaponPrefabVo GetWeaponPrefabVoPrefab(string weaponId);
    }
}
