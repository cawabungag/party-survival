using System;
using InstallerGenerator.Attributes;

namespace InstallerGenerator.Models {
	internal struct AttributeRecord {
		public Type Type;
		public InstallAttribute Attribute;
		public AttributeChanges Changes;

		public AttributeRecord(Type type, InstallAttribute attribute) {
			Type      = type;
			Attribute = attribute;
			Changes = new AttributeChanges {
				Type     = attribute.Type,
				Priority = attribute.Priority,
				Name     = attribute.Name,
				Order    = attribute.Order
			};
		}
	}
}