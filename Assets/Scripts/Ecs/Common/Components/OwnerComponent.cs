﻿using Ecs.Access;
using Ecs.Core;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Common.Components
{
	[Game,Item]
	public class OwnerComponent : IComponent
	{
		[EntityIndex] public Uid Uid;

		public override string ToString() => $"Owner: {Uid}";
	}

	public interface IOwnerProperty : IProperty
	{
		Uid? Owner { get; set; }
	}

	public class OwnerPropertyAccess : IPropertyAccess<IEcsCommonComponentsOwnerEntity, IOwnerProperty>
	{
		public void SetObjectValue(IEcsCommonComponentsOwnerEntity obj, IOwnerProperty property)
		{
			if (!property.Owner.HasValue)
				return;
			obj.ReplaceEcsCommonComponentsOwner(property.Owner.Value);
		}
	
		public void SetPropertyValue(IEcsCommonComponentsOwnerEntity obj, IOwnerProperty property)
		{
			if (!obj.hasEcsCommonComponentsOwner)
				return;
			property.Owner = obj.ecsCommonComponentsOwner.Uid;
		}
	
		public void Reset(IOwnerProperty property)
		{
			property.Owner = default;
		}
	}
}