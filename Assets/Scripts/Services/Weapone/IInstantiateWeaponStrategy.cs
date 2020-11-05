using Ecs.View;
using Zenject;

namespace Services.Weapone
{
	public interface IInstantiateWeaponStrategy : IFactory<ItemEntity, ILinkable>
	{
		bool CanInstantiate(ItemEntity entity);
	}
}