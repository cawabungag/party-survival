using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Ecs.Item.Components
{
	[Item, Event(true)]
	public class PositionComponent : IComponent
	{
		public Vector3 Value;

		public override string ToString()
		{
			return $"Item Position:{Value}";
		}
	}
}