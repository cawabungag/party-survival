using System;
using UnityEngine;

namespace DB.Weapons.Prefabs.Impls
{
   [Serializable]
   public class WeaponPrefabVo
   {
      public EWeaponType _weaponName;
     
      [SerializeField] private GameObject _prefab;
      
      public EWeaponType WeaponId => _weaponName;
      public GameObject Prefab => _prefab;
   }
}
