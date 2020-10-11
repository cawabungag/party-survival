﻿using System.Collections.Generic;
using Entitas;
using Zenject;

namespace Ecs.Core.Systems
{
	public abstract class AReactiveSystemWithPool<TEntity> : IReactiveSystem, IExecuteSystem, ISystem
		where TEntity : class, IEntity
	{
		private static readonly ListPool<TEntity> EntityListPool = ListPool<TEntity>.Instance;

		private readonly ICollector<TEntity> _collector;
		private string _toStringCache;

		protected AReactiveSystemWithPool(IContext<TEntity> context)
		{
			_collector = GetTrigger(context);
		}

		protected AReactiveSystemWithPool(ICollector<TEntity> collector)
		{
			_collector = collector;
		}

		protected abstract ICollector<TEntity> GetTrigger(IContext<TEntity> context);

		protected abstract bool Filter(TEntity entity);

		protected abstract void Execute(List<TEntity> entities);

		public void Activate()
		{
			_collector.Activate();
		}

		public void Deactivate()
		{
			_collector.Deactivate();
		}

		public void Clear()
		{
			_collector.ClearCollectedEntities();
		}

		public void Execute()
		{
			InternalExecute();

			if (_collector.count == 0)
				return;

			var buffer = EntityListPool.Spawn();
			foreach (var collectedEntity in _collector.collectedEntities)
			{
				if (!Filter(collectedEntity))
					continue;
				collectedEntity.Retain(this);
				buffer.Add(collectedEntity);
			}

			_collector.ClearCollectedEntities();
			if (buffer.Count != 0)
			{
				Execute(buffer);
				for (var index = 0; index < buffer.Count; ++index)
					buffer[index].Release(this);
			}

			EntityListPool.Despawn(buffer);
		}

		protected virtual void InternalExecute()
		{
		}

		public override string ToString()
			=> _toStringCache ?? (_toStringCache = "ReactiveSystem(" + GetType().Name + ")");

		~AReactiveSystemWithPool()
		{
			Deactivate();
		}
	}
}