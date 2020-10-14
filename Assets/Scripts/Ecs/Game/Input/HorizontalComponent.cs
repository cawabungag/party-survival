using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Game.Input
{
	[Game, Unique]
	public class HorizontalComponent : IComponent
	{
		public float Value;
		public override string ToString()
		{
			return $"Horizontal: {Value}";
		}
	}
}