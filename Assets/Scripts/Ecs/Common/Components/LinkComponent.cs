using Ecs.View;
using Entitas;

namespace Ecs.Common.Components
{
	[Game, Item]
	public class LinkComponent : IComponent
	{
		public ILinkable Value;

		public override string ToString() => $"Link: {Value.Hash}";
	}
}