using System;
using UnityEngine;

namespace DB.Units.MovementType.MovementSpeedType.Impls
{
    [Serializable]
    public class MovementSpeedTypeVo
    {
        private EMovementType _speedType;
        [SerializeField][Range(0,1)] float _speed;

        public EMovementType SpeedType => _speedType;
        public float Speed => _speed;
        
    }
}