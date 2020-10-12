using System;
using UnityEngine;

namespace DB.Units.Prefabs.Impls
{
	[Serializable]
	public class UnitPrefabVo
	{
		[SerializeField] private string _unitId;
		[SerializeField] private GameObject _prefab;

		public string UnitId => _unitId;
		public GameObject Prefab => _prefab;
	}
}