using System;
using UnityEngine;

namespace DB.Weapons.Prefabs.Impls
{
   [Serializable]
   public class WeaponPrefabVo : MonoBehaviour
   {
      [SerializeField] private string _weaponId;
      [SerializeField] private GameObject _prefab;

      public string WeaponId => _weaponId;
      public GameObject Prefab => _prefab;
   }
}
