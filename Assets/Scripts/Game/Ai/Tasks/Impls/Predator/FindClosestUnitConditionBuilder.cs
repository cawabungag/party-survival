using CleverCrow.Fluid.BTs.Trees;
using Zenject;

namespace Game.Ai.Tasks.Impls
{
	public class FindClosestUnitConditionBuilder : ABTreeBuilder
	{
		private static readonly ListPool<GameEntity> GameEntitiesListPool = ListPool<GameEntity>.Instance;

		private readonly GameContext _game;

		public override string Name => TaskNames.FIND_UNIT;

		public FindClosestUnitConditionBuilder(
			GameContext game
		)
		{
			_game = game;
		}

		public override void Fill(BehaviorTreeBuilder builder, GameEntity entity)
			=> builder.Condition(Name, () =>
			{
				if (!entity.hasEcsGameUnitsRangeView || !entity.hasEcsGamePosition)
					return false;
				var group = _game.GetGroup(GameMatcher.AllOf(GameMatcher.EcsGameFlagsUnit)
					.NoneOf(GameMatcher.EcsGameFlagsDestroyed));
				var buffer = GameEntitiesListPool.Spawn();
				group.GetEntities(buffer);
				if (buffer.Count == 0)
					return false;

				var position = entity.ecsGamePosition.value;
				var rangeView = entity.ecsGameUnitsRangeView.Value;
				var rangeViewSqr = rangeView * rangeView;

				GameEntity closestTarget = null;
				float closestTargetSqrDistance = int.MaxValue;
				foreach (var target in buffer)
				{
					if (!target.hasEcsGamePosition)
						continue;

					var targetPosition = target.ecsGamePosition.value;
					var targetDistance = targetPosition - position;
					var targetDistanceSqr = targetDistance.sqrMagnitude;
					if (targetDistanceSqr > rangeViewSqr || closestTargetSqrDistance < targetDistanceSqr)
						continue;

					closestTargetSqrDistance = targetDistanceSqr;
					closestTarget = target;
				}

				return closestTarget != null;
			});
	}
}