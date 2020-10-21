using System.Collections.Generic;
using Ecs.Core.Systems;
using Entitas;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using UniRx;
using Zenject;

namespace Ecs.Game.System
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 800)]
    public class FindUnitSystem : AReactiveSystemWithPool<GameEntity>
    {
        GameEntity closestUnit = null;
        float closestUnitSqrDistance = int.MaxValue;

        public FindUnitSystem(IContext<GameEntity> context) : base(context)
        {
            
        }

        public FindUnitSystem(ICollector<GameEntity> collector) : base(collector)
        {
            
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            throw new global::System.NotImplementedException();
        }

        protected override bool Filter(GameEntity entity)
        {
            throw new global::System.NotImplementedException();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                
            }
        }
    }

    
}
