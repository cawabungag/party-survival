using System;
using Ecs.View.Impls.Game;
using UnityEngine;

namespace DB.Weapons.Prefabs.Impls
{
	[Serializable]
	public class WeaponPrefabVo
	{
		public EWeaponType _weaponName;

		[SerializeField] private GameObjectView _prefab;

		public EWeaponType WeaponId => _weaponName;
		public GameObjectView Prefab => _prefab;
	}
}