using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Game.Input
{
	[Game, Unique]
	public class VerticalComponent : IComponent
	{
		public float Value;

		public override string ToString()
		{
			return $"Vertical: {Value}";
		}
	}
}