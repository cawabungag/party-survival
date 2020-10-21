using Game.Ai.Tasks;

namespace Game.Ai
{
	public interface IAiTaskBuildersLibrary
	{
		ITaskBuilder Get(string name);
	}
}