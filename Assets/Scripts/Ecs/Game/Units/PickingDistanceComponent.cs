using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Game.Units
{
    [Game, Event(true)]
    public class PickingDistanceComponent : IComponent
    {
        public float Value;
    }
}