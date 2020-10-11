using System.Collections.Generic;
using Entitas;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;

namespace Ecs.Item.Systems
{
	[Install(ExecutionType.Game, ExecutionPriority.Normal, 1000)]
	public class RemoveItemSystem : ReactiveSystem<ItemEntity>
	{
		public RemoveItemSystem(ItemContext item) : base(item)
		{
		}

		protected override ICollector<ItemEntity> GetTrigger(IContext<ItemEntity> context)
			=> context.CreateCollector(ItemMatcher.EcsItemComponentsAmount);

		protected override bool Filter(ItemEntity entity)
			=> entity.hasEcsItemComponentsAmount && !entity.isEcsCommonComponentsDestroyed;

		protected override void Execute(List<ItemEntity> entities)
		{
			foreach (var entity in entities)
			{
				if (entity.ecsItemComponentsAmount.Value > 0)
					continue;
				entity.isEcsCommonComponentsDestroyed = true;
			}
		}
	}
}