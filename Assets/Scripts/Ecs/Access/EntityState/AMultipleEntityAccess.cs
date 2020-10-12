using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Zenject;

namespace Ecs.Access.EntityState
{
	public abstract class AMultipleEntityAccess<TContext, TEntity, TState, TAccess>
		: AEntityAccess<TContext, TEntity, List<TState>, TAccess>
		where TContext : IContext<TEntity>
		where TEntity : class, IEntity
		where TState : TAccess
		where TAccess : IProperty
	{
		private readonly TContext _context;
		private readonly IMemoryPool<TState> _memoryPool;

		protected AMultipleEntityAccess(
			TContext context,
			IObjectAccess<TEntity, TAccess> objectAccess,
			IMemoryPool<TState> memoryPool
		) : base(context, objectAccess)
		{
			_context = context;
			_memoryPool = memoryPool;
		}

		protected override bool Skip(TEntity entity) => false;

		public override void ReadState(List<TState> states)
		{
			var entities = new TEntity[states.Count];
			for (var i = 0; i < states.Count; i++)
			{
				var state = states[i];
				var entity = _context.CreateEntity();
				ObjectAccess.SetState(entity, state);
				entities[i] = entity;
			}

			OnEntitySetState(entities);
		}

		protected virtual void OnEntitySetState(TEntity[] entities)
		{
		}

		public override void WriteState(List<TState> states)
		{
			Group.GetEntities(Buffer);
			Buffer.RemoveAll(Skip);
			var count = Buffer.Count;
			for (var i = 0; i < count; i++)
			{
				var entity = Buffer[i];
				TAccess access = _memoryPool.Spawn();
				ObjectAccess.GetState(entity, ref access);
				try
				{
					states.Add((TState) access);
				}
				catch (Exception)
				{
					Debug.Log("access: " + access + ", states: " + states);
					throw;
				}
			}
		}
	}
}