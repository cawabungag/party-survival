using System;
using Ecs.View.Impls.Game;
using UnityEngine;

namespace DB.Units.EnemyUnit.Prefabs.Impls
{
    [Serializable]
    public class EnemyPrafabVo
    {
        [SerializeField] private EObjectType _unitId;
        [SerializeField] private GameObjectView _prefab;
		
         public EObjectType UnitId => _unitId;
         public GameObjectView Prefab => _prefab;
    }
}