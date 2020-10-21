﻿using Ecs.Access;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ecs.Common.Components
{
	[Game, Event(true)]
	public class NameComponent : IComponent
	{
		public string Value;
	}

	public interface INameProperty : IProperty
	{
		string Name { get; set; }
	}

	// public class NamePropertyAccess : IPropertyAccess<INameEntity, INameProperty>
	// {
	// 	public void SetObjectValue(INameEntity obj, INameProperty property)
	// 	{
	// 		if (!string.IsNullOrEmpty(property.Name))
	// 			return;
	// 		obj.ReplaceName(property.Name);
	// 	}
	//
	// 	public void SetPropertyValue(INameEntity obj, INameProperty property)
	// 	{
	// 		if (!obj.hasName)
	// 			return;
	// 		property.Name = obj.name.Value;
	// 	}
	//
	// 	public void Reset(INameProperty property)
	// 	{
	// 		property.Name = default;
	// 	}
	// }
}