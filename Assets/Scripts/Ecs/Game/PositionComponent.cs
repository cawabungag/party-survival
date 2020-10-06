using Entitas;
using UnityEngine;

namespace Ecs.Game
{
	[Game]
	public class PositionComponent : IComponent
	{
		public Vector2 value;

		public override string ToString()
		{
			return $"Position: {value}";
		}
	}
}