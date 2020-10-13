using System;
using UnityEngine;

[Serializable]
public class WeaponPrefabVo : MonoBehaviour
{
   [SerializeField] private string _weaponId;
   [SerializeField] private GameObject _prefab;

   public string WeaponId => _weaponId;
   public GameObject Prefab => _prefab;
}
