using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Common.Components
{
	[Game, Item, Event(true)]
	public class DestroyedComponent : IComponent
	{
		public override string ToString() => "Destroyed";
	}
}