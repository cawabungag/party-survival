using DB.Weapons;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Item.Components
{
    [Game, Event(true)]
    public class WeaponEquippedComponent : IComponent
    {
        public EWeaponType Value;
        public override string ToString() => "Weapon: " + Value;
    }
}