using Entitas;

namespace Ecs.Item.Components
{
	[Item]
	public class AmountComponent : IComponent
	{
		public int Value;
		public override string ToString()
		{
			return $"Amount: {Value}";
		}
	}
}