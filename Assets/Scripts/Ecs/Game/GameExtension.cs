using DB.Units;
using DB.Units.MovementType;
using DB.Weapons;
using Ecs.Core;
using UnityEngine;

namespace Ecs.Game
{
	public static class GameExtensions
	{
		public static GameEntity CreateUnit(this GameContext context, EObjectType unitType, Vector3 position)
		{
			var entity = context.CreateEntity();
			entity.AddEcsCommonComponentsUid(UidGenerator.Next());
			entity.AddEcsGameObjectType(unitType);
			entity.AddEcsGamePosition(position);
			entity.AddEcsGameDesiredDirectional(Vector2.zero);
			entity.AddEcsGameMovementType(EMovementType.Walk);
			entity.isEcsGameFlagsInstantiated = true;
			entity.isEcsGameFlagsUnit = true;
			return entity;
		}
		public static GameEntity CreateEnemy(this GameContext context, EObjectType unitType, Vector3 position)
		{
			var entity = context.CreateEntity();
			entity.AddEcsCommonComponentsUid(UidGenerator.Next());
			entity.AddEcsGameObjectType(unitType);
			entity.AddEcsGamePosition(position);
			entity.AddEcsGameDesiredDirectional(Vector2.zero);
			entity.AddEcsGameMovementType(EMovementType.Walk);
			entity.isEcsGameFlagsInstantiated = true;
			entity.isEnemy = true;
			return entity;
		}

		public static GameEntity CreateWeapon(this GameContext context, EWeaponType weaponType, Vector3 position)
		{
			var entity = context.CreateEntity();
			entity.AddEcsItemComponentsWeaponType(weaponType);
			entity.AddEcsGamePosition(position);
			entity.AddEcsGameDesiredDirectional(Vector2.zero);
			return entity;
		}
	}
}