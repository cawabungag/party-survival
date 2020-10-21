using DB.Units.Characteristics.Impls;

namespace DB.Units.Characteristics
{
	public interface IUnitCharacteristicDatabase
	{
		UnitCharacteristicVo GetCharacteristics(EObjectType unitId);
	}
}