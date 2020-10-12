using System.Collections.Generic;
using Entitas;

namespace Ecs.Access.EntityState
{
	public abstract class AEntityAccess<TContext, TEntity, TState, TAccess> : IAccess<TState>
		where TContext : IContext<TEntity>
		where TEntity : class, IEntity
		where TAccess : IProperty
	{
		protected readonly List<TEntity> Buffer = new List<TEntity>();
		protected readonly IGroup<TEntity> Group;
		protected readonly IObjectAccess<TEntity, TAccess> ObjectAccess;

		protected AEntityAccess(TContext context, IObjectAccess<TEntity, TAccess> objectAccess)
		{
			ObjectAccess = objectAccess;
			Group = context.GetGroup(GetMatcher());
		}

		public abstract void ReadState(TState states);

		public abstract void WriteState(TState state);

		protected abstract IMatcher<TEntity> GetMatcher();

		protected abstract bool Skip(TEntity entity);
	}
}