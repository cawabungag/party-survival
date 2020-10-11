
using Core.Utils.AppVersion;

namespace Ecs.Access.Utils.Patch
{
	public interface IPersistencePatch
	{
		Version Version { get; }
		void ApplyPatch();
	}
}