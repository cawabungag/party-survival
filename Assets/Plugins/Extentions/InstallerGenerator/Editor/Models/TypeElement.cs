using System;
using InstallerGenerator.Attributes;

namespace InstallerGenerator.Models
{
	public class TypeElement
	{
		public readonly Type Type;
		public readonly int Order;
		public readonly string Name;
		public readonly bool IsDebug;

		public TypeElement(Type type, int order, string name)
		{
			Type = type;
			Order = order;
			Name = name;
		}

		public TypeElement(Type type, InstallAttribute attribute, bool isDebug)
		{
			Type = type;
			Order = attribute.Order;
			Name = attribute.Name;
			IsDebug = isDebug;
		}
	}
}