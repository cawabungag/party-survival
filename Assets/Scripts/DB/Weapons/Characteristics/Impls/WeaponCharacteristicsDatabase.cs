using System;
using DB.Units;
using UnityEngine;

namespace DB.Weapons.Characteristics.Impls
{
    [CreateAssetMenu(menuName = "Installers/WeaponCharacteristicDatabase", fileName = "WeaponCharacteristicDatabase")]
    public class WeaponCharacteristicsDatabase : ScriptableObject, IWeaponCharacteristicsDatabase
    {
        [SerializeField] private WeaponCharacteristicsVo[] _weaponCharacteristicVos;

        public WeaponCharacteristicsVo GetWeaponCharacteristicsVo(EWeaponType weaponId)
        {
            for (int i = 0; i < _weaponCharacteristicVos.Length; i++)
            {
                WeaponCharacteristicsVo weaponCharacteristicsVo = _weaponCharacteristicVos[i];

                if (weaponCharacteristicsVo.WeaponId == weaponId) // Исправить
                {
                    return weaponCharacteristicsVo;
                }
            }
        
            throw new ArgumentException($"[{nameof(WeaponCharacteristicsDatabase)}] No WeaponCharacteristicVo for WeaponId:{weaponId}");
        }
    }
}

