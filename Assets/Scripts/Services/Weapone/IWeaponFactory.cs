using Ecs.View;
using Zenject;

namespace Services.Weapone
{
    public interface IWeaponFactory : IFactory<GameEntity, ILinkable>
    {
    }
}