using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Game.Flags
{
    [Game, Event(true)]
    public class ItemEquippedComponent : IComponent
    {
        public override string ToString()
        {
            return "Is Equipped";
        }
    }
}