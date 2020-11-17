using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using DB.Units;
using Entitas;
using UnityEngine;
using Zenject;

namespace Game.Ai.Tasks.Impls.PlayerUnit
{
    public class AimingBuilder : ABTreeBuilder

    {
        private readonly GameContext _game;

        public AimingBuilder(GameContext game)
        {
            _game = game;
        }
        
        public override string Name => TaskNames.AIMING_ENEMY;
        public override void Fill(BehaviorTreeBuilder builder, GameEntity entity) 
            => builder.Do(Name, () =>
            {
                if (!entity.hasEcsGamePosition)
                    return TaskStatus.Failure;

                Vector2 position = entity.ecsGamePosition.value;
                var turningSpeed = entity.ecsGameUnitsTurningSpeed.Value;
                var targetPosition = entity.ecsGamePosition.value;
                Vector3 newVector3 = new Vector3(targetPosition.x,0,targetPosition.y);
                var directional = targetPosition - position;
                var lookRotation = Quaternion.LookRotation(newVector3);
              //  var rotation = Quaternion.Lerp(, lookRotation, turningSpeed)
                //    .eulerAngles;
             //  position.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);
                    
                return TaskStatus.Success;
            });
    }
}