using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Ecs.Core;
using UnityEngine;

namespace Game.Ai.Tasks.Impls.Enemy
{
	public class GoToTargetActionBuilder : ABTreeBuilder
	{
		private readonly GameContext _game;

		private GoToTargetActionBuilder(GameContext game)
		{
			_game = game;
		}

		public override string Name => TaskNames.GO_TO_TARGET;

		public override void Fill(BehaviorTreeBuilder builder, GameEntity entity)
			=> builder.Do(Name, () =>
			{
				if (!entity.hasEcsGamePosition || !entity.hasEcsGameTarget)
					return TaskStatus.Failure;

				Vector2 position = entity.ecsGamePosition.value;
				Uid targetUid = entity.ecsGameTarget.Value;
				GameEntity targetEntity = _game.GetEntityWithEcsCommonComponentsUid(targetUid);
				if (targetEntity == null)
				{
					entity.RemoveEcsGameTarget();
					return TaskStatus.Failure;
				}

				Vector2 targetPosition = targetEntity.ecsGamePosition.value;
				Vector2 distance = targetPosition - position;
				if (distance.sqrMagnitude > 0.2f)
				{
					entity.ReplaceEcsGameDesiredDirectional(distance.normalized);
					return TaskStatus.Continue;
				}

				entity.ReplaceEcsGameDesiredDirectional(Vector2.zero);
				return TaskStatus.Success;
			});
	}
}