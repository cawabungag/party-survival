using Entitas;

namespace Ecs.Game
{
	[Game]
	public class MoveEndTimeComponent : IComponent
	{
		public float Value;

		public override string ToString()
		{
			return $"MoveEndTime: {Value}";
		}
	}
}