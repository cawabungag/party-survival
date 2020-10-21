using System;
using Ecs.View.Impls.Game;
using UnityEngine;

namespace DB.Units.Prefabs.Impls
{
	[Serializable]
	public class UnitPrefabVo
	{
		[SerializeField] private EObjectType _unitId;
		[SerializeField] private UnitObjectView _prefab;
		
		public EObjectType UnitId => _unitId;
		public UnitObjectView Prefab => _prefab;
		
	}
}