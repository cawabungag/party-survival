using System;
using Entitas;

namespace Ecs.Access.EntityState
{
	public abstract class ASingleEntityAccess<TContext, TEntity, TState, TAccess>
		: AEntityAccess<TContext, TEntity, TState, TAccess>
		where TContext : IContext<TEntity>
		where TEntity : class, IEntity
		where TState : TAccess, new()
		where TAccess : IProperty
	{
		private readonly TContext _context;


		protected ASingleEntityAccess(TContext context, IObjectAccess<TEntity, TAccess> objectAccess) :
			base(context, objectAccess)
		{
			_context = context;
		}

		protected override bool Skip(TEntity entity) => false;

		public override void ReadState(TState state)
		{
			var entity = _context.CreateEntity();
			ObjectAccess.SetState(entity, state);
			OnEntitySetState(entity);
		}

		protected virtual void OnEntitySetState(TEntity entity)
		{
		}

		public override void WriteState(TState state)
		{
			Group.GetEntities(Buffer);
			TAccess access = state;
			if (Buffer.Count <= 0)
				return;
			if (Buffer.Count > 1)
				throw new Exception("[ASingleEntityAccess] Has more one entity.");
			var entity = Buffer[0];
			if (!Skip(entity)) ObjectAccess.GetState(entity, ref access);
		}
	}
}