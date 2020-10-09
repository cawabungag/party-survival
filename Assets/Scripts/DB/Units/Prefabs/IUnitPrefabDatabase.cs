using DB.Units.Prefabs.Impls;

namespace DB.Units.Prefabs
{
	public interface IUnitPrefabDatabase
	{
		UnitPrefabVo GetUnitPrefab(string unitId);
	}
}