using System;
using DB.Units;
using UnityEngine;

namespace DB.Weapons.Prefabs.Impls
{
    [CreateAssetMenu(menuName = "Installers/WeaponPrefabDatabase", fileName = "WeaponPrefabDatabase")]
    public class WeaponPrefabDatabase : ScriptableObject, IWeaponPrefabDatabase
    {
        [SerializeField] private WeaponPrefabVo[] _weaponPrefabVos; 
    
        public WeaponPrefabVo GetWeaponPrefabVoPrefab(EWeaponType weaponId)
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
