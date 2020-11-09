using Ecs.Core;
using Entitas;

namespace Ecs.Item.Components
{
    [Game]
    public class PickingItemComponent : IComponent
    {
        public Uid Value;
        public override string ToString() => "Item: " + Value;
    }
}