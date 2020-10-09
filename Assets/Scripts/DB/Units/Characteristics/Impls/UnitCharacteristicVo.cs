using System;

namespace DB.Units.Characteristics.Impls
{
	[Serializable]
	public class UnitCharacteristicVo
	{
		private string _unitId;
		private float _health;
		private float _speed;
		private float _rangeView;

		public float Health => _health;
		public float Speed => _speed;
		public float RangeView => _rangeView;
		public string UnitId => _unitId;
	}
}