using DB.Units;
using Ecs.Access;
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

	public interface IObjectTypeProperty : IProperty
	{
		EObjectType ObjectType { get; set; }
	}

	public class ObjectTypePropertyAccess : IPropertyAccess<GameEntity, IObjectTypeProperty>
	{
		public void SetObjectValue(GameEntity obj, IObjectTypeProperty property)
		{
			obj.ReplaceEcsGameObjectType(property.ObjectType);
		}
	
		public void SetPropertyValue(GameEntity obj, IObjectTypeProperty property)
		{
			property.ObjectType = obj.ecsGameObjectType.Value;
		}
	
		public void Reset(IObjectTypeProperty property)
		{
			property.ObjectType = default;
		}
	}
}