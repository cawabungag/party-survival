﻿using System.Collections.Generic;
using Ecs.Core;

namespace Game.Services.Items
{
	public interface IItemService
	{
		List<ItemVo> GetItems(Uid ownerId);
		
		bool HasItems(Uid ownerUid, params ItemVo[] items);

		bool HasItemWithType(Uid ownerUid, EItemType type);

		int GetItemAmount(Uid ownerUid, EItemType type);

		void AddItems(Uid recipientUid, params ItemVo[] items);

		void MoveItems(Uid ownerUid, Uid recipientUid, params ItemVo[] items);

		void RemoveItems(Uid ownerUid, params ItemVo[] items);

		int ConsumeItem(Uid ownerUid, ItemVo item);
	}
}