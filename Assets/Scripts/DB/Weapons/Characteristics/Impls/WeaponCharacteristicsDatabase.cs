using System;
using DB.Units;
using UnityEngine;

namespace DB.Weapons.Characteristics.Impls
{
    public class WeaponCharacteristicsDatabase : ScriptableObject, IWeaponCharacteristicsDatabase
    {
        [SerializeField] private WeaponCharacteristicsVo[] _weaponCharacteristicVos;

        public WeaponCharacteristicsVo GetWeaponCharacteristicsVO(EObjectType weaponId)
        {
            for (int i = 0; i < _weaponCharacteristicVos.Length; i++)
            {
                WeaponCharacteristicsVo weaponCharacteristicsVo = _weaponCharacteristicVos[i];

                if (weaponCharacteristicsVo.WeaponId == weaponId)
                {
                    return weaponCharacteristicsVo;
                }
            }
        
            throw new ArgumentException($"[{nameof(WeaponCharacteristicsDatabase)}] No WeaponCharacteristicVo for WeaponId:{weaponId}");
        }

   
    }
}

