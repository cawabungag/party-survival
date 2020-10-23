using System.Collections.Generic;
using Ecs.Game.Camera;
using Entitas;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using UnityEngine;
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
		private const float CAMERA_DIFF = 10f;

		public CameraMoveSystem(GameContext gameContext, ICameraView camera)
		{
			_mainCamera = camera;
			_gameContext = gameContext;
			_group = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.EcsGameFlagsUnit)
				.NoneOf(GameMatcher.EcsGameFlagsDestroyed));
		}

		public void Execute()
		{
			List<GameEntity> buffer = GameEntitiesListPool.Spawn();
			_group.GetEntities(buffer);
			for (int i = 0; i < buffer.Count; i++)
			{
				GameEntity entity = buffer[i];
				if (!entity.hasEcsGamePosition || !entity.isEcsGameFlagsUnit
				) continue;
				{
					Vector2 unitPosition = entity.ecsGamePosition.value;
					UnityEngine.Camera camera = _mainCamera.GetCamera();
					Transform transform = camera.transform;
					Vector3 cameraPosition = transform.position;
					cameraPosition.x = unitPosition.x;
					cameraPosition.z = unitPosition.y - CAMERA_DIFF;
					transform.position = cameraPosition;
				}
			}

			GameEntitiesListPool.Despawn(buffer);
		}
	}
}