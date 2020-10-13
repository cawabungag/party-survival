using System;
using DB.Weapons.Characteristics;
using DB.Weapons.Characteristics.Impls;
using UnityEngine;


public class WeaponCharacteristicsDatabase : ScriptableObject, IWeaponCharacteristicsDatbase
{
    [SerializeField] private WeaponCharacteristicsVo[] _weaponCharacteristicVos;

    public WeaponCharacteristicsVo GetWeaponCharacteristicsVO(string weaponId)
    {
        for (int i = 0; i < _weaponCharacteristicVos.Length; i++)
        {
            WeaponCharacteristicsVo weaponCharacteristicsVo = _weaponCharacteristicVos[i];

            if (weaponCharacteristicsVo.WeaponId == weaponId)
            {
                return weaponCharacteristicsVo;
            }
        }
        
        throw new ArgumentException(
            $"[{nameof(WeaponCharacteristicsDatabase)}] No WeaponCharacteristicVo for WeaponId:{weaponId}");
    }
}

