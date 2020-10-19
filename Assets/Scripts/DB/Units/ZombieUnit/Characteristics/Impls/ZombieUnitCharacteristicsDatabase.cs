using System;
using UnityEngine;

namespace DB.Units.ZombieUnit.Characteristics.Impls
{
    [CreateAssetMenu(menuName = "Installers/ZombieCharacteristicDatabase", fileName = "ZombieCharacteristicDatabase")]
    public class ZombieUnitCharacteristicsDatabase : ScriptableObject, IZombieCharacteristicsDatabase
    {
        [SerializeField] private ZombieUnitCharacteristicVo[] _zombieUnitCharacteristicsVos;

        public ZombieUnitCharacteristicVo GetCharacteristics(EObjectType unitId)
        {
            for (int i = 0; i < _zombieUnitCharacteristicsVos.Length; i++)
            {
                ZombieUnitCharacteristicVo zombieUnitCharacteristicsVo = _zombieUnitCharacteristicsVos[i];

                if (zombieUnitCharacteristicsVo.UnitId == unitId)
                {
                    return zombieUnitCharacteristicsVo;
                }
            }
            throw new ArgumentException($"[{nameof(ZombieUnitCharacteristicsDatabase)}] No ZombieUnitCharacteristicVo for UnitId:{unitId}");
        }
    }
}
