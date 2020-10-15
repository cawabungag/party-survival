using System;
using UnityEngine;

namespace DB.Units.Prefabs.Impls
{
	[CreateAssetMenu(menuName = "Installers/UnitPrefabDatabase", fileName = "UnitPrefabDatabasex")]
	public class UnitPrefabDatabase : ScriptableObject, IUnitPrefabDatabase
	{
		[SerializeField] private UnitPrefabVo[] _unitPrefabVos;

		public UnitPrefabVo GetUnitPrefab(EObjectType unitId)
		{
			for (int i = 0; i < _unitPrefabVos.Length; i++)
			{
				UnitPrefabVo unitPrefabVo = _unitPrefabVos[i];
				if (unitPrefabVo.UnitId == unitId)
				{
					return unitPrefabVo;
				}
			}

			throw new ArgumentException($"[{nameof(UnitPrefabDatabase)}] No prefab for UnitId:{unitId}");
		}
	}
}