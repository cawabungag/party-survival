using Entitas;

namespace Ecs.Game.Weapons
{
    [Game]
    public class FiringFrequencyComponent : IComponent
    {
        public float Value;

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
