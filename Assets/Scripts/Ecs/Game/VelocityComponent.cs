using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Ecs.Game
{
	[Game, Event(true)]
	public class VelocityComponent : IComponent
	{
		public Vector2 Value;

		public bool IsMoving() => Value.sqrMagnitude > 0.001f;

		public override string ToString() => $"Velocity: {Value}";
	}
}