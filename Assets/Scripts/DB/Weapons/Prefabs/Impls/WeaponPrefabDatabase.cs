using System;
using UnityEngine;

namespace DB.Weapons.Prefabs.Impls
{
    public class WeaponPrefabDatabase : ScriptableObject, IWeaponPrefavDatabase
    {
        [SerializeField] private WeaponPrefabVo[] _weaponPrefabVos; 
    
        public WeaponPrefabVo GetWeaponPrefabVoPrefab(string weaponId)
        {
            for (int i = 0; i < _weaponPrefabVos.Length; i++)
            {
                WeaponPrefabVo weaponPrefabVo = _weaponPrefabVos[i];
                if (weaponPrefabVo.WeaponId == weaponId)
                {
                    return weaponPrefabVo;
                }
            }
        
            throw new ArgumentException(
                $"[{nameof(WeaponPrefabDatabase)}] No WeaponPrefabCVo for WeaponPrefabId:{weaponId}");
        }
    }
}
