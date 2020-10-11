// ﻿using System.Collections.Generic;
// using Ecs.Core;
// using Ecs.Item;
//
// namespace Game.Services.Items.Impls
// {
// 	public class ItemService : IItemService
// 	{
// 		private readonly ItemContext _item;
//
// 		public ItemService(ItemContext item)
// 		{
// 			_item = item;
// 		}
//
// 		public List<ItemVo> GetItems(Uid ownerId)
// 		{
// 			var list = new List<ItemVo>();
// 			var itemEntities = _item.GetEntitiesWithOwner(ownerId);
// 			foreach (var itemEntity in itemEntities)
// 				list.Add(new ItemVo(itemEntity.itemType.Value, itemEntity.amount.Value));
//
// 			return list;
// 		}
//
// 		public bool HasItems(Uid ownerUid, params ItemVo[] items)
// 		{
// 			var itemEntities = _item.GetEntitiesWithOwner(ownerUid);
// 			for (var i = 0; i < items.Length; i++)
// 			{
// 				var item = items[i];
// 				var result = false;
// 				foreach (var entity in itemEntities)
// 				{
// 					if (entity.itemType.Value != item.type || entity.amount.Value < item.amount)
// 						continue;
// 					result = true;
// 					break;
// 				}
//
// 				if (!result)
// 					return false;
// 			}
//
// 			return true;
// 		}
//
// 		public bool HasItemWithType(Uid ownerUid, EItemType type)
// 		{
// 			var itemEntity = GetItemEntity(ownerUid, type);
// 			return itemEntity != null;
// 		}
//
// 		public int GetItemAmount(Uid ownerUid, EItemType type)
// 		{
// 			var itemEntity = GetItemEntity(ownerUid, type);
// 			return itemEntity?.amount.Value ?? 0;
// 		}
//
// 		public void AddItems(Uid recipientUid, params ItemVo[] items)
// 		{
// 			for (var i = 0; i < items.Length; i++)
// 			{
// 				var item = items[i];
// 				if (item.amount == 0)
// 					continue;
//
// 				var itemEntity = GetItemEntity(recipientUid, item.type);
// 				if (itemEntity != null)
// 					itemEntity.ReplaceAmount(itemEntity.amount.Value + item.amount);
// 				else
// 					_item.CreateItem(recipientUid, item.type, item.amount);
// 			}
// 		}
//
// 		public void MoveItems(Uid ownerUid, Uid recipientUid, params ItemVo[] items)
// 		{
// 			var ownerItemEntities = _item.GetEntitiesWithOwner(ownerUid);
// 			for (var i = 0; i < items.Length; i++)
// 			{
// 				var item = items[i];
// 				var result = false;
// 				foreach (var entity in ownerItemEntities)
// 				{
// 					if (entity.itemType.Value != item.type)
// 						continue;
//
// 					var amount = entity.amount.Value;
// 					if (amount < item.amount)
// 						throw new System.Exception(
// 							$"[{nameof(ItemService)}] Owner with uid {ownerUid} do not have required item type {item.type} amount {item.amount}");
// 					amount -= item.amount;
// 					entity.ReplaceAmount(amount);
// 					result = true;
// 					break;
// 				}
//
// 				if (!result)
// 					throw new System.Exception(
// 						$"[{nameof(ItemService)}] Owner with uid {ownerUid} do not have item with type {item.type}");
// 			}
//
// 			AddItems(recipientUid, items);
// 		}
//
// 		public void RemoveItems(Uid ownerUid, params ItemVo[] items)
// 		{
// 			var itemEntities = _item.GetEntitiesWithOwner(ownerUid);
// 			for (var i = 0; i < items.Length; i++)
// 			{
// 				var item = items[i];
// 				var result = false;
// 				foreach (var entity in itemEntities)
// 				{
// 					if (entity.itemType.Value != item.type)
// 						continue;
//
// 					var amount = entity.amount.Value;
// 					if (amount < item.amount)
// 						throw new System.Exception(
// 							$"[{nameof(ItemService)}] Owner with uid {ownerUid} do not have required item type {item.type} amount {item.amount}");
// 					amount -= item.amount;
// 					entity.ReplaceAmount(amount);
// 					result = true;
// 					break;
// 				}
//
// 				if (!result)
// 					throw new System.Exception(
// 						$"[{nameof(ItemService)}] Owner with uid {ownerUid} do not have item with type {item.type}");
// 			}
// 		}
//
// 		public int ConsumeItem(Uid ownerUid, ItemVo item)
// 		{
// 			var itemEntity = GetItemEntity(ownerUid, item.type);
// 			if (itemEntity == null)
// 				return 0;
//
// 			var amount = itemEntity.amount.Value;
// 			var consumed = amount >= item.amount ? item.amount : amount;
// 			itemEntity.ReplaceAmount(amount - consumed);
// 			return consumed;
// 		}
//
// 		private ItemEntity GetItemEntity(Uid ownerUid, EItemType itemType)
// 		{
// 			var itemEntities = _item.GetEntitiesWithOwner(ownerUid);
// 			foreach (var entity in itemEntities)
// 			{
// 				if (entity.itemType.Value == itemType)
// 					return entity;
// 			}
//
// 			return null;
// 		}
// 	}
// }