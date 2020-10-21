using Ecs.Core;
using Entitas;

namespace Ecs.Game.Flags
{
    [Game]
    public class WeaponIdComponent : IComponent
    {
        public Uid weaponId;
    }
}