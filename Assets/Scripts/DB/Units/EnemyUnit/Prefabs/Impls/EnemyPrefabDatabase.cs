using System;
using UnityEngine;

namespace DB.Units.EnemyUnit.Prefabs.Impls
{
    [CreateAssetMenu(menuName = "Installers/ZombieUnitPrefabDatabase", fileName = "ZombieUnitPrefabDatabase")]
    public class EnemyPrefabDatabase : ScriptableObject, IEnemyPrefabDatabase
    {
        [SerializeField] private EnemyPrafabVo[] _enemyPrefabVos;
    
        public EnemyPrafabVo GetZombiePrefab(EObjectType unitId)
        {
            for (int i = 0; i < _enemyPrefabVos.Length; i++)
            {
                EnemyPrafabVo zombieUnitPrafabVo = _enemyPrefabVos[i];
                if (zombieUnitPrafabVo.UnitId == unitId)
                {
                    return zombieUnitPrafabVo;
                }
            }
            
            throw new ArgumentException($"[{nameof(EnemyPrefabDatabase)}] No prefab for UnitId:{unitId}");
        }
    }
    
}