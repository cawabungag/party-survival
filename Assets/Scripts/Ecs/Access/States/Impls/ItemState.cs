using System;
using Ecs.Core;
using Game.Services.Items;

namespace Ecs.Access.States.Impls
{
	[Serializable]
	public class ItemState : IItemState
	{
		public Uid Uid { get; set; }
		public Uid? Owner { get; set; }
		public EItemType ItemType { get; set; }
		public int Amount { get; set; }
	}
}