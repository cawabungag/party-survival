using Ecs.View;
using Zenject;

namespace Services.Unit
{
	public interface IUnitFactory : IFactory<GameEntity, ILinkable>
	{
	}
}