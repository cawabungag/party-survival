using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Ecs.Game
{
	[Game, Event(true)]
	public class PositionComponent : IComponent
	{
		public Vector2 value;

		public override string ToString()
		{
			return $"Position: {value}";
		}
	}
}