using System;
using UnityEngine;

namespace DB.Units.Characteristics.Impls
{ 
	public class UnitCharacteristicDatabase : ScriptableObject, IUnitCharacteristicDatabase
	{
		[SerializeField] private UnitCharacteristicVo[] _unitCharacteristicVos;

		public UnitCharacteristicVo GetCharacteristics(string unitId)
		{
			for (int i = 0; i < _unitCharacteristicVos.Length; i++)
			{
				UnitCharacteristicVo unitCharacteristicVo = _unitCharacteristicVos[i];
				if (unitCharacteristicVo.UnitId == unitId)
				{
					return unitCharacteristicVo;
				}
			}

			throw new ArgumentException(
				$"[{nameof(UnitCharacteristicDatabase)}] No UnitCharacteristicVo for UnitId:{unitId}");
		}
	}
}