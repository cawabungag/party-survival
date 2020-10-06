using Entitas;
using UnityEngine;

namespace Ecs.Game
{
	[Game]
	public class DirectionComponent : IComponent
	{
		public Vector2 value;

		public override string ToString()
		{
			return $"Directional: {value}";
		}
	}
}