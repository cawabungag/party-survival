using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using DB.Units;
using Entitas;
using UnityEngine;
using Zenject;

namespace Game.Ai.Tasks.Impls.Enemy
{
	public class FindClosestUnitsBuilder : ABTreeBuilder
	{
		private static readonly ListPool<GameEntity> GameEntitiesListPool = ListPool<GameEntity>.Instance;
		private readonly GameContext _game;

		public override string Name => TaskNames.FIND_UNITS;

		public FindClosestUnitsBuilder(
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
				IGroup<GameEntity> group = _game.GetGroup(
					GameMatcher.AllOf(GameMatcher.EcsGameObjectType)
						.NoneOf(GameMatcher.EcsGameFlagsDestroyed));
				List<GameEntity> buffer = GameEntitiesListPool.Spawn();
				group.GetEntities(buffer);
				if (buffer.Count == 0)
					return false;

				Vector2 position = entity.ecsGamePosition.value;
				float rangeView = entity.ecsGameUnitsRangeView.Value;
				float rangeViewSqr = rangeView * rangeView;
				GameEntity closestUnit = null;
				float closestFoodSqrDistance = int.MaxValue;

				foreach (GameEntity unit in buffer)
				{
					if (!unit.hasEcsGamePosition)
						continue;
					if (unit.ecsGameObjectType.Value != EObjectType.ZombieUnit)
						continue;

					Vector2 unitPosition = unit.ecsGamePosition.value;
					Vector2 unitDistance = unitPosition - position;
					float unitDistanceSqrMagnitude = unitDistance.sqrMagnitude;
					if (unitDistanceSqrMagnitude > rangeViewSqr || closestFoodSqrDistance < unitDistanceSqrMagnitude)
						continue;

					closestFoodSqrDistance = unitDistanceSqrMagnitude;
					closestUnit = unit;
				}

				if (closestUnit != null)
				{
					entity.ReplaceEcsGameTarget(closestUnit.ecsCommonComponentsUid.Value);
					return true;
				}

				return false;
			});
	}
}