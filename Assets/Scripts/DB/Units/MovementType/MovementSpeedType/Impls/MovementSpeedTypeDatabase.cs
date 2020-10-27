using System;
using UnityEngine;

namespace DB.Units.MovementType.MovementSpeedType.Impls
{
    [CreateAssetMenu(menuName = "Installers/MovementSpeedDatabase", fileName = "UMovementSpeedDatabase")]
    public class MovementSpeedTypeDatabase : ScriptableObject, IMovementSpeedType
    {
        [SerializeField] private MovementSpeedTypeVo[] _movementSpeedTypeVos;
        
        public MovementSpeedTypeVo GetMovementSpeed(EMovementType moveSpeed)
        {
            for (int i = 0; i < _movementSpeedTypeVos.Length; i++)
            {
                MovementSpeedTypeVo movementSpeedTypeVo = _movementSpeedTypeVos[i];
                if (movementSpeedTypeVo.SpeedType == moveSpeed)
                {
                    return movementSpeedTypeVo;
                }
            }

            throw new ArgumentException(
                $"[{nameof(MovementSpeedTypeDatabase)}] No MovementSpeedTypeVo for SpeedType:{moveSpeed}");
        }
        
    }
}