using Ecs.View;
using Zenject;

namespace Services.Weapone
{
	public interface IItemFactory : IFactory<ItemEntity, ILinkable>
	{
	}
}