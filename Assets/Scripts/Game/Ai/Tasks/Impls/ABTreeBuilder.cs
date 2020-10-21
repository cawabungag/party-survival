﻿using CleverCrow.Fluid.BTs.Trees;

namespace Game.Ai.Tasks.Impls
{
	public abstract class ABTreeBuilder : ITaskBuilder
	{
		public abstract string Name { get; }

		public abstract void Fill(BehaviorTreeBuilder builder, GameEntity entity);

		public virtual void End(BehaviorTreeBuilder builder)
		{
		}
	}
}