using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Ecs.Input
{
	[Input, Unique]
	public class DirectionalComponent : IComponent
	{
		public Vector2 Value;

		public override string ToString()
		{
			return $"Directional: {Value}";
		}
	}
}