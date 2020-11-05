using System.Collections.Generic;
using Ecs.Core.Systems;
using Ecs.View;
using Entitas;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using Services.Weapone;

namespace Ecs.Game.System
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 130)]
	public class InstantiateItemSystem : AReactiveSystemWithPool<ItemEntity>
	{
		private readonly ItemContext _item;
		private readonly IItemFactory _itemFactory;

		public InstantiateItemSystem(
			ItemContext item, IItemFactory itemFactory
		) : base(item)
		{
			_item = item;
			_itemFactory = itemFactory;
		}

		protected override ICollector<ItemEntity> GetTrigger(IContext<ItemEntity> context) =>
			context.CreateCollector(ItemMatcher.EcsGameFlagsInstantiated);

		protected override bool Filter(ItemEntity entity) =>
			entity.isEcsGameFlagsInstantiated && !entity.hasEcsCommonComponentsLink &&
			!entity.isEcsCommonComponentsDestroyed;

		protected override void Execute(List<ItemEntity> entities)
		{
			foreach (ItemEntity entity in entities)
			{
				ILinkable linkable = _itemFactory.Create(entity);
				linkable.Link(entity, _item);
				entity.AddEcsCommonComponentsLink(linkable);
			}
		}
	}
}