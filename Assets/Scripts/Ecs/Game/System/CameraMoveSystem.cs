using Ecs.Game.Camera;
using Entitas;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using Zenject;

namespace Ecs.Game.System
{
    [Install(ExecutionType.Game, ExecutionPriority.Normal, 780)]
    public class CameraMoveSystem : IExecuteSystem
    {
        private static readonly ListPool<GameEntity> GameEntitiesListPool = ListPool<GameEntity>.Instance;
        private readonly IGroup<GameEntity> _group;
        private readonly GameContext _gameContext;
        private readonly ICameraView _mainCamera;

        public CameraMoveSystem(GameContext gameContext, ICameraView camera)
        {
            _mainCamera = camera;
            _gameContext = gameContext; 
            _group = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.EcsGameFlagsUnit).NoneOf(GameMatcher.EcsGameFlagsDestroyed));
            
        }
        
        public void Execute()
        {
            var buffer = GameEntitiesListPool.Spawn(); 
            _group.GetEntities(buffer);
            for (var i = 0; i < buffer.Count; i++) 
            {
                GameEntity entity = buffer[i];
                
                if (!entity.hasEcsGamePosition || !entity.hasEcsGameDesiredDirectional || !entity.hasEcsGameUnitsSpeed || !_gameContext.hasEcsGameInputDirectional) continue;
                {
                    _mainCamera.GetCamera().transform.position = entity.ecsGamePosition.value;
                    GameEntitiesListPool.Despawn(buffer);
                }
            }
        }
    }
}