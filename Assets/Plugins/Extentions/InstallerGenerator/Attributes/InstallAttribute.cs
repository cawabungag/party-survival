using System;
using InstallerGenerator.Enums;

namespace InstallerGenerator.Attributes {
	public class InstallAttribute : Attribute {
		public readonly ExecutionType Type;
		public readonly ExecutionPriority Priority;
		public readonly int Order;
		public readonly string Name;

		public InstallAttribute(
			ExecutionType type,
			ExecutionPriority priority = ExecutionPriority.None,
			int order = 100000,
			string name = ""
		) {
			Type     = type;
			Priority = priority;
			Order    = order;
			Name     = name;
		}
	}
}
