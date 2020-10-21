using DB.Units.MovementType;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Game
{
	[Game, Event(true)]
	public class MovementTypeComponent : IComponent
	{
		public EMovementType Value;

		public override string ToString()
		{
			return $"Movement type: {Value}";
		}
	}
}