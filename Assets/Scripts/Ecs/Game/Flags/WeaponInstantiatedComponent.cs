using Entitas;

namespace Ecs.Game.Flags
{
    [Game]
    public class WeaponInstantiatedComponent : IComponent
    {
        public override string ToString()
        {
            return "Weapon Is Instantiated";
        }
    }
    
}