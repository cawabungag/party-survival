using System;
using DB.Units;
using UnityEngine;

namespace DB.Weapons.Prefabs.Impls
{
   [Serializable]
   public class WeaponPrefabVo
   {
      public EObjectType _weaponId;
      [SerializeField] private GameObject _prefab;

      public EObjectType WeaponId => _weaponId;
      public GameObject Prefab => _prefab;
   }
}
