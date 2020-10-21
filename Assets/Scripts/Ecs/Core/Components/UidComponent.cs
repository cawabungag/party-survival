using Ecs.Access;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Core.Components
{
	[Game, Item]
	public class UidComponent : IComponent
	{
		[PrimaryEntityIndex] public Uid Value;

		public override string ToString() => Value.ToString();
	}

	public interface IUidProperty : IProperty
	{
		Uid Uid { get; set; }
	}

	public class UidPropertyAccess : IPropertyAccess<IEcsCommonComponentsUidEntity, IUidProperty>
	{
		public void SetObjectValue(IEcsCommonComponentsUidEntity obj, IUidProperty property)
		{
			UidGenerator.Reserve(property.Uid);
			obj.ReplaceEcsCommonComponentsUid(property.Uid);
		}
	
		public void SetPropertyValue(IEcsCommonComponentsUidEntity obj, IUidProperty property)
		{
			property.Uid = obj.ecsCommonComponentsUid.Value;
		}
	
		public void Reset(IUidProperty property)
		{
			property.Uid = default;
		}
	}
}