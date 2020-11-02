using System.Collections.Generic;
using Ecs.Core.Systems;
using Entitas;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using Services.Weapone;

namespace Ecs.Game.System
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 130)]
    public class InstantiateWeaponSystem : AReactiveSystemWithPool<GameEntity>
    {
        private readonly GameContext _game;
        private readonly IWeaponFactory _weaponFactory;

        public InstantiateWeaponSystem(
            GameContext game, IWeaponFactory weaponFactory
        ) :base(game)
        {
            _game = game;
            _weaponFactory = weaponFactory;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.EcsGameFlagsWeaponInstantiated);

        protected override bool Filter(GameEntity entity) => 
            entity.isEcsGameFlagsWeaponInstantiated && !entity.hasEcsCommonComponentsLink && 
            !entity.isEcsCommonComponentsDestroyed;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var linkable = _weaponFactory.Create(entity);
                linkable.Link(entity, _game);
                entity.AddEcsCommonComponentsLink(linkable);
            }
        }
    }
}