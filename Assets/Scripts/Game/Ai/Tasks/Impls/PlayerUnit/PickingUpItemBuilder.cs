using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;

namespace Game.Ai.Tasks.Impls.PlayerUnit
{
	public class PickingUpItemBuilder : ABTreeBuilder
	{
		private readonly ItemContext _item;

		public PickingUpItemBuilder(ItemContext item)
		{
			_item = item;
		}

		public override string Name => TaskNames.PICK_UP_ITEM;

		public override void Fill(BehaviorTreeBuilder builder, GameEntity entity)
			=> builder.Do(Name, () => TaskStatus.Success);
	}
}