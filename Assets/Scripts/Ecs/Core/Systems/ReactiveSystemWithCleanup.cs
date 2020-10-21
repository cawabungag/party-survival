using System.Collections.Generic;
using Entitas;

namespace Ecs.Core.Systems
{
	public abstract class ReactiveSystemWithCleanup<TEntity> : ReactiveSystem<TEntity>
		where TEntity : class, IEntity
	{
		protected ReactiveSystemWithCleanup(IContext<TEntity> context) : base(context)
		{
		}

		protected ReactiveSystemWithCleanup(ICollector<TEntity> collector) : base(collector)
		{
		}

		protected override void Execute(List<TEntity> entities)
		{
			foreach (var entity in entities)
			{
				entity.Destroy();
			}
		}
	}
}