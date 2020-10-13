﻿using Ecs.Core;
 using Services.Items;

 namespace Ecs.Item
{
	public static class ItemExtensions
	{
		public static ItemEntity CreateItem(this ItemContext context, Uid ownerUid, EItemType type, int amount)
		{
			var entity = context.CreateEntity();
			entity.AddEcsCommonComponentsUid(UidGenerator.Next());
			entity.AddEcsCommonComponentsOwner(ownerUid);
			entity.AddEcsItemComponentsItemType(type);
			entity.AddEcsItemComponentsAmount(amount);
			return entity;
		}
	}
}