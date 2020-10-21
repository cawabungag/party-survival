using System;
using UnityEngine;

namespace DB.Units.EnemyUnit.Characteristics.Impls
{
    [CreateAssetMenu(menuName = "Installers/ZombieCharacteristicDatabase", fileName = "ZombieCharacteristicDatabase")]
    public class EnemyCharacteristicsDatabase : ScriptableObject, IEnemyCharacteristicsDatabase
    {
        [SerializeField] private EnemyCharacteristicVo[] _enemyUnitCharacteristicsVos;

        public EnemyCharacteristicVo GetCharacteristics(EObjectType unitId)
        {
            for (int i = 0; i < _enemyUnitCharacteristicsVos.Length; i++)
            {
                EnemyCharacteristicVo enemyUnitCharacteristicsVo = _enemyUnitCharacteristicsVos[i];

                if (enemyUnitCharacteristicsVo.UnitId == unitId)
                {
                    return enemyUnitCharacteristicsVo;
                }
            }
            throw new ArgumentException($"[{nameof(EnemyCharacteristicsDatabase)}] No ZombieUnitCharacteristicVo for UnitId:{unitId}");
        }
    }
}
