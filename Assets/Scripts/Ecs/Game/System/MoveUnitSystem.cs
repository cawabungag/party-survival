using Entitas;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using UnityEngine;
using Zenject;

namespace Ecs.Game.System
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 700)]
	public class MoveUnitSystem : IExecuteSystem
	{
		private static readonly ListPool<GameEntity> GameEntitiesListPool = ListPool<GameEntity>.Instance;

		private readonly IGroup<GameEntity> _group;

		private readonly GameContext _gameContext;

		public MoveUnitSystem(
			GameContext gameContext
		)
		{
			_gameContext = gameContext;
			_group = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.EcsGameFlagsUnit)
				.NoneOf(GameMatcher.EcsGameFlagsDestroyed));
		}

		public void Execute()
		{
			var buffer = GameEntitiesListPool.Spawn();
			_group.GetEntities(buffer);

			for (var i = 0; i < buffer.Count; i++)
			{
				var entity = buffer[i];
				if (!entity.hasEcsGamePosition || !entity.hasEcsGameDesiredDirectional || !entity.hasEcsGameUnitsSpeed || !_gameContext.hasEcsGameInputDirectional)
					continue;

				var desiredDirection = _gameContext.ecsGameInputDirectional.Value;
				entity.ReplaceEcsGameDesiredDirectional(desiredDirection);

				var speed = entity.ecsGameUnitsSpeed.Value;
				var velocity = speed * Time.deltaTime * desiredDirection;
				entity.ReplaceEcsGameVelocity(velocity);
			}

			GameEntitiesListPool.Despawn(buffer);
		}
	}
}