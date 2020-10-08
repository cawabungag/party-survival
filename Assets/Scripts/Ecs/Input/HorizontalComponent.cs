using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Input
{
	[Input, Unique]
	public class HorizontalComponent : IComponent
	{
		public float Value;
		public override string ToString()
		{
			return $"Horizontal: {Value}";
		}
	}
}