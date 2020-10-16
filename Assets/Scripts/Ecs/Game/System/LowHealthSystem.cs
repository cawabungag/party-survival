using System.Collections.Generic;
using Entitas;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;

namespace Ecs.Game.System
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 500)]
    
    public class LowHealthSystem : ReactiveSystem<GameEntity>
    {
        public LowHealthSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) 
             => context.CreateCollector(GameMatcher.EcsGameUnitsHealth);

        protected override bool Filter(GameEntity entity)
            => entity.isEcsGameFlagsInstantiated && !entity.hasEcsCommonComponentsLink &&
               !entity.isEcsCommonComponentsDestroyed && entity.hasEcsGameUnitsHealth;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.ecsGameUnitsHealth.Value <= 0)
                { 
                    entity.Destroy();
                }
            }
            
        }
    }
}