using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Ecs.Core;
using UnityEngine;
using Zenject;

namespace Game.Ai.Tasks.Impls.PlayerUnit
{
    public class AttackEnemyBuilder : ABTreeBuilder 
    {
	    private readonly GameContext _game;

	    public AttackEnemyBuilder(GameContext game)
	    {
		    _game = game;
	    }
        public override string Name => TaskNames.ATTACK_ENEMY;
      
        public override void Fill(BehaviorTreeBuilder builder, GameEntity entity)
	        => builder.Do(Name, () =>
	        { 
		        if (!entity.hasEcsGameAttackTarget) 
			        return TaskStatus.Failure;
		        
       				Uid targetUid = entity.ecsGameAttackTarget.Value;
       				GameEntity targetEntity = _game.GetEntityWithEcsCommonComponentsUid(targetUid);
       				if (targetEntity == null || !targetEntity.hasEcsGameUnitsHealth)
       					return TaskStatus.Failure;
       
       				float damage = entity.ecsItemWeaponsDamage.Value;
       				float targetEntityHealth = targetEntity.ecsGameUnitsHealth.Value;
       				float newTargetEntityHealth = targetEntityHealth - damage;
       				targetEntity.ReplaceEcsGameUnitsHealth(newTargetEntityHealth);
                    
       				return TaskStatus.Success;
                    
                    
	        });
    }
}