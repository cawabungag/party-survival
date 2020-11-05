using System;
using DB.Units;
using DB.Units.MovementType;
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
			_group = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.EcsGameObjectType)
				.NoneOf(GameMatcher.EcsGameFlagsDestroyed));
		}

		public void Execute()
		{
			var buffer = GameEntitiesListPool.Spawn();
			_group.GetEntities(buffer);

			for (int i = 0; i < buffer.Count; i++)
			{
				GameEntity entity = buffer[i];
				if (!entity.hasEcsGamePosition || !entity.hasEcsGameDesiredDirectional ||
				    !entity.hasEcsGameUnitsSpeed || !_gameContext.hasEcsGameInputDirectional || entity.ecsGameObjectType.Value != EObjectType.Unit)
					continue;
				Vector2 desiredDirection = _gameContext.ecsGameInputDirectional.Value;
				entity.ReplaceEcsGameDesiredDirectional(desiredDirection);
				float speed = entity.ecsGameUnitsSpeed.Value;
				Vector2 velocity = speed * Time.deltaTime * desiredDirection;
				entity.ReplaceEcsGameVelocity(velocity);

				float x = desiredDirection.x;
				float y = desiredDirection.y;
				if (x.Equals(0) && y.Equals(0))
				{
					entity.ReplaceEcsGameMovementType(EMovementType.Idle);
				}
				else if
					(Math.Abs(x) >= 0.5 || Math.Abs(y) >= 0.5)
				{
					entity.ReplaceEcsGameMovementType(EMovementType.Run);
				}
				else
				{
					entity.ReplaceEcsGameMovementType(EMovementType.Walk);
				}
			}

			GameEntitiesListPool.Despawn(buffer);
		}
	}
}