using System;

namespace DB.Units.ZombieUnit.Characteristics.Impls
{
    [Serializable]
    public class ZombieUnitCharacteristicVo
    {
        public EObjectType _unitId;
        public float _health;
        public float _speed;
        public float _rangeView;

        public float Health => _health;
        public float Speed => _speed;
        public float RangeView => _rangeView;
        public EObjectType UnitId => _unitId;
    }
}
