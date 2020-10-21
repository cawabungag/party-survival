using Ecs.Core.Interfaces;

namespace Ecs.Core.Impls
{
	public class UnityTimeProvider : ITimeProvider
	{
		public float Time => UnityEngine.Time.realtimeSinceStartup;
		public float DeltaTime => UnityEngine.Time.deltaTime;
		public float FixedDeltaTime => UnityEngine.Time.fixedDeltaTime;
	}
}