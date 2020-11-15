using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using DB.Units;
using Ecs.Core;
using Entitas;
using UnityEngine;
using Zenject;

namespace Game.Ai.Tasks.Impls.PlayerUnit
{
    public class EnemyDetectionBuilder : ABTreeBuilder
    {
        private static readonly ListPool<GameEntity> GameEntitiesListPool = ListPool<GameEntity>.Instance;
        private readonly GameContext _game;
        
        public override string Name => TaskNames.FIND_ENEMY;

        EnemyDetectionBuilder(
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
               
                GameEntity closestEnemy = null;
                float closestEnemySqrDistance = int.MaxValue;

                foreach (GameEntity unit in buffer)
                {
                     if (!unit.hasEcsGamePosition)
                        continue;
                     
                    if (unit.ecsGameObjectType.Value != EObjectType.ZombieUnit)
                        continue;

                    if (unit.ecsGameObjectType.Value == EObjectType.ZombieUnit)
                    {
                        Vector2 enemyPosition = unit.ecsGamePosition.value;
                        Vector2 enemyDistance = enemyPosition - position;
                        float enemyDistanceSqrMagnitude = enemyDistance.sqrMagnitude;
                        if (enemyDistanceSqrMagnitude > rangeViewSqr || closestEnemySqrDistance < enemyDistanceSqrMagnitude)
                            continue;
                        
                        closestEnemySqrDistance = enemyDistanceSqrMagnitude;
                        closestEnemy = unit;
                        
                        Uid enemyUid = unit.ecsCommonComponentsUid.Value;
                        if (!unit.hasEcsGameAttackTarget)
                        {
                            unit.AddEcsGameAttackTarget(enemyUid);
                            Debug.Log("Added AttackTargetComponent" + " " + enemyUid);
                            unit.ReplaceEcsGameAttackTarget(Uid.Empty);
                        }
                    }
                    if (closestEnemy != null)
                    {
                        entity.ReplaceEcsGameAttackTarget(closestEnemy.ecsCommonComponentsUid.Value);
                        return true;
                    }
                }
                return false;
            });
    }
}