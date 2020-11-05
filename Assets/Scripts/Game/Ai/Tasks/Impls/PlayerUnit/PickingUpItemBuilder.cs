using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Ecs.Core;
using UnityEngine;

namespace Game.Ai.Tasks.Impls.PlayerUnit
{
    public class PickingUpItemBuilder : ABTreeBuilder
    {
        private readonly GameContext _game;
        
        public PickingUpItemBuilder(GameContext game)
        {
            _game = game;
        }
        public override string Name => TaskNames.PICK_UP_ITEM;
        
        public override void Fill(BehaviorTreeBuilder builder, GameEntity entity)
            => builder.Do(Name, () =>
            {
                if (!entity.isEcsGameFlagsItemEquipped)
                    return TaskStatus.Failure;

                Uid itemUid = entity.ecsGameItemType.Value;
                GameEntity itemEntity = _game.GetEntityWithEcsCommonComponentsUid(itemUid);
                
                entity.Destroy();
                Debug.Log("Weapone Delete");
                return TaskStatus.Success;
            });
    }
}