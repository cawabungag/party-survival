using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Ecs.Core.Interfaces;
using UnityEngine;

namespace Game.Ai.Tasks.Impls.Enemy
{
	public class WanderActionBuilder : ABTreeBuilder
	{
		private static readonly Vector2[] MoveDirections =
		{
			Vector2.up,
			Vector2.down,
			Vector2.right,
			Vector2.left,
			(Vector2.up + Vector2.right).normalized,
			(Vector2.up + Vector2.left).normalized,
			(Vector2.down + Vector2.right).normalized,
			(Vector2.down + Vector2.left).normalized,
		};

		private readonly IRandomProvider _randomProvider;
		private readonly ITimeProvider _timeProvider;

		public WanderActionBuilder(
			IRandomProvider randomProvider,
			ITimeProvider timeProvider
		)
		{
			_randomProvider = randomProvider;
			_timeProvider = timeProvider;
		}

		public override string Name => TaskNames.WANDER;

		public override void Fill(BehaviorTreeBuilder builder, GameEntity entity)
			=> builder.Do(Name, () =>
			{
				var time = _timeProvider.Time;
				if (entity.ecsGameMoveEndTime.Value > time)
					return TaskStatus.Continue;

				var index = _randomProvider.Range(0, MoveDirections.Length);
				entity.ReplaceEcsGameDesiredDirectional(MoveDirections[index]);
				var moveTime = _randomProvider.Range(0.5f, 5f);
				entity.ReplaceEcsGameMoveEndTime(time + moveTime);
				return TaskStatus.Success;
			});
	}
}