using Entitas;
using UnityEngine;

namespace Ecs.Game
{
	[Game]
	public class DesiredDirectionalComponent : IComponent
	{
		public Vector2 value;

		public override string ToString()
		{
			return $"DesiredDirectional: {value}";
		}
	}
}