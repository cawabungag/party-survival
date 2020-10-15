using System.Collections.Generic;
using Ecs.Core.Systems;
using Entitas;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using UnityEngine;

namespace Ecs.Game.System
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 300)]
	public class ApplyVelocityUnitSystem : AReactiveSystemWithPool<GameEntity>
	{
		public ApplyVelocityUnitSystem(
			GameContext game
		) : base(game)
		{
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.EcsGameVelocity);

		protected override bool Filter(GameEntity entity)
			=> entity.hasEcsGameVelocity && entity.hasEcsGamePosition && !entity.isEcsGameFlagsDestroyed;

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var entity in entities)
			{
				var velocity = entity.ecsGameVelocity.Value;
				var position = entity.ecsGamePosition.value;
				entity.ReplaceEcsGamePosition(position + velocity);
			}
		}
	}
}