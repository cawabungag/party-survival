using System;

namespace DB.Units.Characteristics.Impls
{
	[Serializable]
	public class UnitCharacteristicVo
	{
		public EObjectType _unitId;
		public float _health;
		public float _speed;
		public float _rangeView;
		public float _pickingDistance;
		

		public float Health => _health;
		public float Speed => _speed;
		public float RangeView => _rangeView;
		public EObjectType UnitId => _unitId;
		public float PickingDistance => _pickingDistance;
	}
}