using System;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;

namespace Game.Ai
{
	public static class BehaviorTreeExtensions
	{
		public static BehaviorTreeBuilder Do(this BehaviorTreeBuilder builder, string name, Action startLogic,
			Func<TaskStatus> updateLogic)
			=> builder.AddNode(new ActionGeneric
			{
				Name = name,
				startLogic = startLogic,
				updateLogic = updateLogic
			});
	}
}