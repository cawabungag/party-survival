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
        
        throw new System.NotImplementedException();
    }
}

