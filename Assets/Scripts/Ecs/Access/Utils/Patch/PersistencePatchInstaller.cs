using Zenject;

namespace Ecs.Access.Utils.Patch
{
	public class PersistencePatchInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<PersistencePatcher>().AsSingle();
		}
	}
}