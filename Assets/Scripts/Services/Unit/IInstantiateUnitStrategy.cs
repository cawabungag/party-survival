using Ecs.View;
using Zenject;

namespace Services.Unit
{
	public interface IInstantiateUnitStrategy : IFactory<GameEntity, ILinkable>
	{
		bool CanInstantiate(GameEntity entity);
	}
}