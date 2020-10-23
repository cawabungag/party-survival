using DB.Units;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Game
{
	[Game, Event(true)]
	public class ObjectTypeComponent : IComponent
	{
		public EObjectType Value;

		public override string ToString() => "ObjectType: " + Value;
	}
}