using System.Collections.Generic;
using Ecs.Core.Systems;
using Entitas;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using Services.Unit;

namespace Ecs.Game.System
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 750)]
    public class InstantiateWeaponSystem : AReactiveSystemWithPool<GameEntity>
    {
        private readonly GameContext _game;
        private readonly IUnitFactory _objectFactory;
        
        public InstantiateWeaponSystem(
            GameContext game,
            IUnitFactory objectFactory
            ): base(game)
        {
            _game = game;
            _objectFactory = objectFactory;   
        }
        
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
            => context.CreateCollector(GameMatcher.EcsGameFlagsInstantiated);
        

        protected override bool Filter(GameEntity entity)
            => entity.hasEcsGameFlagsWeaponId && !entity.hasEcsCommonComponentsLink &&
               !entity.isEcsCommonComponentsDestroyed;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var linkable = _objectFactory.Create(entity);
                linkable.Link(entity, _game);
                entity.AddEcsCommonComponentsLink(linkable);
            }
        }
    }

    
}