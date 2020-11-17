using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Game.Units
{
	[Game, Event(true)]
	public class HealthComponent : IComponent
	{
		public float Value;
	}
}