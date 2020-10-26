using Entitas;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using Zenject;

namespace Ecs.Game.System
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 800)]
	public class BehaviourTreeTickSystem : IExecuteSystem
	{
		private static readonly ListPool<GameEntity> GameEntitiesListPool = ListPool<GameEntity>.Instance;

		private readonly IGroup<GameEntity> _group;

		public BehaviourTreeTickSystem(GameContext game)
		{
			_group = game.GetGroup(GameMatcher.AllOf(GameMatcher.EcsGameComponentsAiBehaviourTree)
				.NoneOf(GameMatcher.EcsGameFlagsDestroyed));
		}

		public void Execute()
		{
			var buffer = GameEntitiesListPool.Spawn();
			_group.GetEntities(buffer);

			foreach (var entity in buffer)
			{
				entity.ecsGameComponentsAiBehaviourTree.Value.Tick();
			}

			GameEntitiesListPool.Despawn(buffer);
		}
	}
}