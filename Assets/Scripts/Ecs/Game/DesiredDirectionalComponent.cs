using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Ecs.Game
{
	[Game, Event(true)]
	public class DesiredDirectionalComponent : IComponent
	{
		public Vector2 value;

		public override string ToString()
		{
			return $"DesiredDirectional: {value}";
		}
	}
}