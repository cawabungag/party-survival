using DB.Units.AiTasks.Impls;

namespace DB.Units.AiTasks
{
	public interface IAiTaskDatabase
	{
		AiTaskVo GetAiTask(EObjectType unitId);
	}
}