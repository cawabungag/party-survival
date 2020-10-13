using UnityEngine;

public interface IWeaponPrefavDatabase
{
    WeaponPrefabVo GetWeaponPrefabVoPrefab(string weaponId);
}
