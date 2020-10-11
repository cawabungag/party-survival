using Ecs.View;
using Entitas;

namespace Ecs.Common.Components
{
	[Game]
	public class LinkComponent : IComponent
	{
		public ILinkable Value;

		public override string ToString() => $"Link: {Value.Hash}";
	}
}