using System;
using Ecs.Core;
using UnityEngine;

namespace Ecs.Access.States.Impls
{
	[Serializable]
	public class UnitState : IUnitState
	{
		public Uid Uid { get; set; }
		// public EObjectType ObjectType { get; set; }
		public Vector2? Position { get; set; }
		public int? Health { get; set; }
		public int? Hunger { get; set; }
		public Uid? Settlement { get; set; }
		public int? Level { get; set; }
		public string Name { get; set; }
		public int? Defence { get; set; }
		public float? Accuracy { get; set; }
		public float? Dodge { get; set; }
		public int? Kills { get; set; }
		public int? Age { get; set; }
		public int? Experience { get; set; }
		public int? Friends { get; set; }
	}
}