using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using DB.Units;
using DB.Weapons;
using Entitas;
using UnityEngine;
using Zenject;

namespace Game.Ai.Tasks.Impls.PlayerUnit
{
    public class ItemDetectionBuilder : ABTreeBuilder
    {
        private static readonly ListPool<GameEntity> GameEntitiesListPool = ListPool<GameEntity>.Instance;
            private readonly GameContext _game;

            public override string Name => TaskNames.FIND_ITEM;

            public ItemDetectionBuilder(
                GameContext game
            )
            {
                _game = game;
            }

            public override void Fill(BehaviorTreeBuilder builder, GameEntity entity)
                => builder.Condition(Name, () =>
                {
                    if (!entity.hasEcsGameUnitsPickingDistance || !entity.hasEcsGamePosition)
                        return false;
                    
                    IGroup<GameEntity> group = _game.GetGroup(
                        GameMatcher.AllOf(GameMatcher.EcsGameUnitsPickingDistance)
                            .NoneOf(GameMatcher.EcsGameFlagsDestroyed));
                    List<GameEntity> buffer = GameEntitiesListPool.Spawn();
                    group.GetEntities(buffer);
                    if (buffer.Count == 0)
                        return false;

                    Vector2 position = entity.ecsGamePosition.value;
                    float pickingDistance = entity.ecsGameUnitsPickingDistance.Value;
                    float rangeViewSqr = pickingDistance * pickingDistance;
                    GameEntity closestItem = null;
                    float closestItemSqrDistance = int.MaxValue;

                    foreach (var item in buffer)
                    {
                        if (!item.hasEcsGamePosition)
                            continue;

                        Vector2 itemPosition = item.ecsGamePosition.value;
                        Vector2 itemDistance = itemPosition - position;
                        float itemDistanceSqrMagnitude = itemDistance.sqrMagnitude;
                        if (itemDistanceSqrMagnitude > rangeViewSqr || closestItemSqrDistance < itemDistanceSqrMagnitude)
                            continue;

                        closestItemSqrDistance = itemDistanceSqrMagnitude;
                        closestItem = item;
                    }

                    if (closestItem != null)
                    {
                        entity.ReplaceEcsGameTarget(closestItem.ecsCommonComponentsUid.Value);
                        return true;
                    }

                    return false;
                });
        
    }
}