using System;
using DB.Units.ZombieUnit.Prefabs.Impls;
using UnityEngine;

namespace DB.Units.ZombieUnit.Prefabs.Impls
{
    [CreateAssetMenu(menuName = "Installers/ZombieUnitPrefabDatabase", fileName = "ZombieUnitPrefabDatabase")]
    public class ZombieUnitPrefabDatabase : ScriptableObject, IZombieUnitPrefabDatabase
    {
        [SerializeField] private ZombieUnitPrafabVo[] _zombieUnitPrefabVos;
    
        public ZombieUnitPrafabVo GetZombiePrefab(EObjectType unitId)
        {
            for (int i = 0; i < _zombieUnitPrefabVos.Length; i++)
            {
                ZombieUnitPrafabVo zombieUnitPrafabVo = _zombieUnitPrefabVos[i];
                if (zombieUnitPrafabVo.UnitId == unitId)
                {
                    return zombieUnitPrafabVo;
                }
            }
            
            throw new ArgumentException($"[{nameof(ZombieUnitPrefabDatabase)}] No prefab for UnitId:{unitId}");
        }
    }
    
}