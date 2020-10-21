using System;

namespace Services.Items
{
	[Serializable]
	public struct ItemVo
	{
		public EItemType type;
		public int amount;

		public ItemVo(EItemType type, int amount)
		{
			this.type = type;
			this.amount = amount;
		}

		public bool IsEmpty() => type == EItemType.None && amount == 0;

		public bool Equals(ItemVo other) => type == other.type && amount == other.amount;

		public override bool Equals(object obj) => obj is ItemVo other && Equals(other);

		public override int GetHashCode()
		{
			unchecked
			{
				return ((int) type * 397) ^ amount;
			}
		}

		public override string ToString() => $"{nameof(type)}: {type}, {nameof(amount)}: {amount}";
	}
}