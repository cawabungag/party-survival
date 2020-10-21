using Entitas;

namespace Ecs.Core.Interfaces
{
	public interface IDisposeSystem : ISystem
	{
		void Dispose();
	}
}