using CleverCrow.Fluid.BTs.Trees;
using DB.Units.AiTasks;
using DB.Units.AiTasks.Impls;
using Game.Ai.Tasks;

namespace Game.Ai.Impls
{
	public class BehaviourTreeFactory : IBehaviourTreeFactory
	{
		private readonly IAiTaskBuildersLibrary _taskBuildersLibrary;
		private readonly IAiTaskDatabase _aiTaskDatabase;
		private IBehaviourTreeFactory m_behaviourTreeFactoryImplementation;

		public BehaviourTreeFactory(
			IAiTaskBuildersLibrary taskBuildersLibrary, IAiTaskDatabase aiTaskDatabase
		)
		{
			_taskBuildersLibrary = taskBuildersLibrary;
			_aiTaskDatabase = aiTaskDatabase;
		}

		public IBehaviorTree Create(GameEntity param)
		{
			BehaviorTreeBuilder builder = new BehaviorTreeBuilder(null);
			AiTaskVo aiTaskVo = _aiTaskDatabase.GetAiTask(param.ecsGameObjectType.Value);
			string[] tasks = aiTaskVo.taskNames;
			ITaskBuilder taskBuilder = null;
			foreach (string task in tasks)
			{
				taskBuilder = _taskBuildersLibrary.Get(task);
				taskBuilder.Fill(builder, param);
			}

			taskBuilder?.End(builder);
			return builder.Build();
		}
	}
}