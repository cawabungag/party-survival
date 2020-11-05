using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Ecs.Core;

namespace Game.Ai.Tasks.Impls
{
	public class AttackActionBuilder : ABTreeBuilder
	{
		private readonly GameContext _game;

		public AttackActionBuilder(GameContext game)
		{
			_game = game;
		}

		public override string Name => TaskNames.ATTACK;

		public override void Fill(BehaviorTreeBuilder builder, GameEntity entity)
			=> builder.Do(Name, () =>
			{
				if (!entity.hasEcsItemWeaponsDamage || !entity.hasEcsGameAttackTarget)
					return TaskStatus.Failure;

				Uid targetUid = entity.ecsGameAttackTarget.Value;
				GameEntity targetEntity = _game.GetEntityWithEcsCommonComponentsUid(targetUid);
				if (targetEntity == null || !targetEntity.hasEcsGameUnitsHealth)
					return TaskStatus.Failure;

				float damage = entity.ecsItemWeaponsDamage.Value;
				float targetEntityHealth = targetEntity.ecsGameUnitsHealth.Value;
				float newTargetEntityHealth = targetEntityHealth - damage;
				targetEntity.ReplaceEcsGameUnitsHealth((int) newTargetEntityHealth);
				return TaskStatus.Success;
			});
	}
}