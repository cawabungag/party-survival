using Ecs.Core;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Common.Components
{
	[Game, Item]
	public class OwnerComponent : IComponent
	{
		[EntityIndex] public Uid Uid;

		public override string ToString() => $"Owner: {Uid}";
	}
}