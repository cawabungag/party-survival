using System;
using Ecs.View.Impls.Game;
using UnityEngine;

namespace DB.Units.Prefabs.Impls
{
	[Serializable]
	public class UnitPrefabVo
	{
		[SerializeField] private EObjectType _unitId;
		[SerializeField] private GameObjectView _prefab;
		
		public EObjectType UnitId => _unitId;
		public GameObjectView Prefab => _prefab;
		
	}
}