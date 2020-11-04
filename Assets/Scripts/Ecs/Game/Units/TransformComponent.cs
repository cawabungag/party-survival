using Entitas;
using UnityEngine;

namespace Ecs.Game.Units
{
    [Game]
    public class TransformComponent : IComponent
    {
        public Transform UnitTransformPosition;
    }
}