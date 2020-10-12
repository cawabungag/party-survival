using Entitas;

namespace Ecs.View
{
	public interface ILinkableListener
	{
		void Listen(IEntity entity);
		void Unlisten(IEntity entity);
		void Unlink();
		void Clear();
	}
}