using Ecs.View;
using Zenject;

namespace Services.Weapone
{
    public interface IInstantiateWeaponStrategy : IFactory<GameEntity, ILinkable>
    {
        bool CanInstantiate(GameEntity entity);
    }
}