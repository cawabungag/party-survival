using Entitas;

namespace Ecs.View
{
	public interface ILinkable : IEntityHashHolder
	{
		void Link(IEntity entity, IContext context);
		void Destroy();
	}
}