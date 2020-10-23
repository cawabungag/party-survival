using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Core.Components
{
	[Game, Item]
	public class UidComponent : IComponent
	{
		[PrimaryEntityIndex] public Uid Value;

		public override string ToString() => Value.ToString();
	}
}