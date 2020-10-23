using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Common.Components
{
	[Game, Event(true)]
	public class NameComponent : IComponent
	{
		public string Value;
	}
}